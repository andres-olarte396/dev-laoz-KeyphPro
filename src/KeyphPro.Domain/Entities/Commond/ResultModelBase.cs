namespace KeyphPro.Domain.Entities.Commond
{
    public class ResultModelBase<TModel>
    {
        public ResultModelBase(TModel model, int code = 200, string? message = default)
        {
            Result = model;
            Code = code;
            Message = message ?? "Success";
            Success = code >= 200 && code < 300;
        }
        public ResultModelBase(string message, int code = 500)
        {
            Result = default;
            Code = code;
            Message = message;
            Success = false;
        }

        public ResultModelBase()
        {
        }

        public TModel? Result { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}