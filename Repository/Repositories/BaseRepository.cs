using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository
    {
        protected const int TamanhoPagina = 5;

        protected readonly MyAppContext _context;
        public BaseRepository(MyAppContext context)
        {
            this._context = context;
        }
    }
}
