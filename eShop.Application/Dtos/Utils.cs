using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Dtos
{
    public static class Utils
    {
        public static int renderPage(this int page)
        {
            page = page <= 1 ? 1 : page;
            return page;
        }       
        public static int renderSize(this int size)
        {
            size = size <= 0 ? 10 : size;
            return size;
        }
    }
}
