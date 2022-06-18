namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class PotvrdaGetByParamsRequest
    {
        public int? StudentId { get; set; }

        public bool PagedResult { get; set; } = true;

        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; }
    }
}
