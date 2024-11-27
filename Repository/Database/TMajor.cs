using Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class TMajor:CD
    {

        public string Name { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// 對應學生列表
        /// </summary>
        public virtual List<TStudent> Students { get; set; }
        /// <summary>
        /// 對應老師列表
        /// </summary>
        public virtual List<TTeacher>Teachers { get; set; }

    }
}
