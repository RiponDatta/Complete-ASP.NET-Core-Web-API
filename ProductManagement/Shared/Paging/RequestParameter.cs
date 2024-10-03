namespace Shared.Paging
{
    public class RequestParameter
    {
        const int maxPageSize = 10;
        public int PageNumber { get; set; }

        private int _pageSize = 5;
        
        public int PageSize { 
            get
            { 
                return _pageSize;
            }
            set
            {
                _pageSize = value > maxPageSize ? _pageSize : value;
            } 
        }
    }
}
