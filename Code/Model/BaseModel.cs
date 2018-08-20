namespace Model
{
    class BaseModel
    {
    }

    public class ReturnResult
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }

        public ReturnResult()
        {
            this.Success = false;
            this.Code = "0";
            this.Msg = string.Empty;

        }

    }

    public class PageInfo
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
        public int totalCount { get; set; }
        public string ID { get; set; }
        public string onPageIndexChangeClientFunction { get; set; }

        public PageInfo()
        {
            pageIndex = 0;
            pageSize = 0;
            pageCount = 0;
            totalCount = 0;
            ID = string.Empty;
            onPageIndexChangeClientFunction = string.Empty;
        }

    }
}
