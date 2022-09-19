namespace IceSync.DomainModel.Models.Configurations
{
    public class Credential
    {
        public Credential(string apicompanyId, string apiUserId, string apiUserSecret)
        {
            this.ApiCompanyId = apicompanyId;
            this.ApiUserId = apiUserId;
            this.ApiUserSecret = apiUserSecret;
        }
        public string ApiCompanyId { get; set; }
        public string ApiUserId { get; set; }
        public string ApiUserSecret { get; set; }
    }
}
