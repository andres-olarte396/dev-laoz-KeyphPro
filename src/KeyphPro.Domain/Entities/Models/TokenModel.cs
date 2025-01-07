namespace KeyphPro.Domain.Entities.Models
{
    public class TokenModel
    {
        /// <summary>
        /// Unique identifier for the token.
        /// </summary>
        public Guid TokenId { get; set; }

        /// <summary>
        /// Value of the token.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The user associated with this token.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Expiration date and time of the token.
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Indicates whether the token is currently active.
        /// </summary>
        public bool IsActive => DateTime.UtcNow <= Expiration;

        /// <summary>
        /// Date and time when the token was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// IP address or origin where the token was created (optional).
        /// </summary>
        public string CreatedByIp { get; set; }

        /// <summary>
        /// Date and time when the token was revoked, if applicable.
        /// </summary>
        public DateTime? RevokedAt { get; set; }

        /// <summary>
        /// IP address or origin where the token was revoked (optional).
        /// </summary>
        public string RevokedByIp { get; set; }

        /// <summary>
        /// Reason for token revocation, if applicable.
        /// </summary>
        public string RevocationReason { get; set; }

        /// <summary>
        /// Indicates if the token has been revoked.
        /// </summary>
        public bool IsRevoked => RevokedAt.HasValue;

        /// <summary>
        /// Indicates if the token is valid (active and not revoked).
        /// </summary>
        public bool IsValid => IsActive && !IsRevoked;

        /// <summary>
        /// Navigation property for the associated user.
        /// </summary>
        public UserModel User { get; set; }
    }

}
