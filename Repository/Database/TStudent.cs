using Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class TStudent:CD
    {

        public long Name { get; set; }

        public string Phone {  get; set; }



        /// <summary>
        /// 導師信息
        /// </summary>

        public long TeacherId { get; set; }
        public virtual TTeacher Teacher { get; set; }

        /// <summary>
        /// 專業信息
        /// </summary>
        public long MajorId { get; set; }
        public virtual TMajor Major { get; set; }

    }
}
