using Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{


    /// <summary>
    /// 社團成員信息
    /// </summary>

    public class TClubStudent:CD
    {

        /// <summary>
        /// 社團信息
        /// </summary>
        public long ClubId { get; set; }
        public virtual TClub Club { get; set; }


        /// <summary>
        /// 成員信息
        /// </summary>
        public long StudentId { get; set; }

        public virtual TStudent Student { get; set; }
    }
}
