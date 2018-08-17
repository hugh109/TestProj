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
        public int _pageIndex { get; set; }
        public int _pageSize { get; set; }
        public int _pageCount { get; set; }
        public int _totalCount { get; set; }
        public string _ID { get; set; }
        public string _onPageIndexChangeClientFunction { get; set; }

        public PageInfo()
        {
            _pageIndex = 0;
            _pageSize = 0;
            _pageCount = 0;
            _totalCount = 0;
            _ID = string.Empty;
            _onPageIndexChangeClientFunction = string.Empty;
        }

    }
}
