using AutoMapper;
using KeyphPro.Application.Commond;
using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Database;
using KeyphPro.Domain.Entities.Models;
using KeyphPro.Domain.Repositories;
using KeyphPro.Domain.Services;

namespace KeyphPro.Application.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IBasicService<AssessmentModel, Assessment, int> _basicService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<BasicService<AssessmentModel, Assessment, int>> _logger;

        public AssessmentService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<BasicService<AssessmentModel, Assessment, int>> logger,
            IBasicService<AssessmentModel, Assessment, int> basicService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _basicService = basicService;
        }

        public ResultModelBase<IEnumerable<string>> CheckWarningConditions(decimal bodyFat, decimal muscleMass)
        {
            var warnings = new List<string>();

            // Validación de parámetros
            if (bodyFat < 10 || bodyFat > 40)
                warnings.Add("La grasa corporal debe estar entre 10% y 40%.");
            if (muscleMass < 25 || muscleMass > 45)
                warnings.Add("La masa muscular debe estar entre 25% y 45%.");

            // Validar que la suma esté aproximadamente en 100% (±5%)
            var totalPercentage = bodyFat + muscleMass;
            if (totalPercentage < 40 || totalPercentage > 80)
                warnings.Add("La suma de grasa corporal y masa muscular debe ser menor a 70% y mayor a 40%.");

            // Validar rango saludable para grasa corporal
            if (bodyFat < 10 || bodyFat > 35)
                warnings.Add("La grasa corporal está fuera del rango saludable (10% - 35%).");

            // Crear resultado
            var result = new ResultModelBase<IEnumerable<string>>
            {
                Result = warnings.Any() ? warnings : null,
                Success = !warnings.Any(),
                Message = warnings.Any() ? "Se encontraron condiciones de advertencia." : "No hay condiciones de advertencia."
            };

            return result;
        }
        public decimal ComputeBMI(decimal weight, decimal height)
        {
            // Validaciones iniciales
            if (weight <= 0)
                throw new ArgumentException("El peso debe ser mayor que cero.", nameof(weight));
            if (height <= 0)
                throw new ArgumentException("La altura debe ser mayor que cero.", nameof(height));

            // Convertir la altura de cm a metros
            decimal heightInMeters = height / 100;

            // Cálculo del BMI
            decimal bmi = weight / (heightInMeters * heightInMeters);

            // Redondear el resultado a dos decimales para mayor claridad
            return Math.Round(bmi, 2);
        }

        public Task<ResultModelBase<AssessmentModel>> CreateAssessment(AssessmentModel assessment)
        {
            return _basicService.AddAsync(assessment);
        }

        public Task<ResultModelBase<AssessmentModel>> GetAssessment(int assessmentId)
        {
            return _basicService.GetByIdAsync(assessmentId);
        }

        public async Task<ResultModelBase<IEnumerable<AssessmentModel>>> GetAssessmentsByUser(Guid userId)
        {
            try
            {
                var assessments = await _unitOfWork.QueryRepository<Assessment, int>().GetByQueryAsync(x => x.UserId == userId);
                var result = _mapper.Map<IEnumerable<AssessmentModel>>(assessments);
                return new ResultModelBase<IEnumerable<AssessmentModel>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {typeof(AssessmentModel)}", ex);
                return new ResultModelBase<IEnumerable<AssessmentModel>>(ex.Message);
            }
        }

        public Task<ResultModelBase<bool>> UpdateAssessment(int assessmentId, AssessmentModel assessment)
        {
            return _basicService.UpdateAsync(assessment);
        }

        public ResultModelBase<bool> ValidateAssessmentData(AssessmentModel assessment)
        {
            var results = _basicService.Validate(assessment);
            if (results.Count != 0)
            {
                var msg = string.Join("\n - ", results);
                return new ResultModelBase<bool>(msg);
            }

            return new ResultModelBase<bool>(true, 200, "Success");
        }
    }
}
