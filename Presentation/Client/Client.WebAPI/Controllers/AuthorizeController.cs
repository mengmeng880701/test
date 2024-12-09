using IdentifierGenerator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Repository.Database;
using Shared.Interface;
using Shared.Model;
using Shared.Model.Authorize;
using System.Xml;
using WebAPI.Core.Filters;

namespace Client.WebAPI.Controllers
{


    /// <summary>
    /// 系统访问授权模块
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthorizeController(IAuthorizeService authorizeService) : ControllerBase
    {

        //[HttpGet]
        //public void Test([FromServices] DatabaseContext db, IdService idService)
        //{


        //    //輸入major資料
        //    TMajor major = new();
        //    major.Id = idService.GetId();
        //    major.Name = "國文";

        //    db.TMajor.Add(major);//插入表中

        //    db.SaveChanges();//保存

        //    TMajor major2 = new();
        //    major.Id = idService.GetId();
        //    major.Name = "英文";

        //    db.TMajor.Add(major);//插入表中

        //    db.SaveChanges();//保存

        //    TMajor major3 = new();
        //    major.Id = idService.GetId();
        //    major.Name = "數學";

        //    db.TMajor.Add(major);//插入表中

        //    db.SaveChanges();//保存


        //    //輸入學生表資料
        //    TStudent student = new TStudent();
        //    student.Id = idService.GetId();
        //    student.Name = "小明";
        //    student.Phone = "0978135363";   

        //    db.TStudent.Add(student);
        //    db.SaveChanges();

        //    TStudent student2 = new TStudent();
        //    student.Id = idService.GetId();
        //    student.Name = "小華";
        //    student.Phone = "451325765";

        //    db.TStudent.Add(student);
        //    db.SaveChanges();

        //    TStudent student3 = new TStudent();
        //    student.Id = idService.GetId();
        //    student.Name = "小張";
        //    student.Phone = "451155525";

        //    db.TStudent.Add(student);
        //    db.SaveChanges();

        //    //輸入社團表資料
        //    TClub club = new TClub();
        //    club.Id = idService.GetId();
        //    club.Name = "籃球社";

        //    db.Add(club);
        //    db.SaveChanges();

        //    TClub club1 = new TClub();
        //    club.Id = idService.GetId();
        //    club.Name = "足球社";

        //    db.Add(club);
        //    db.SaveChanges();

        //    TClub club2 = new TClub();
        //    club.Id = idService.GetId();
        //    club.Name = "羽球社";

        //    db.TClub.Add(club);***與db.Add(club);
        //    db.SaveChanges();

        //    //多對多學生查詢資料表
        //    TClubStudent clubStudent = new TClubStudent();
        //    clubStudent.Id = idService.GetId();
        //    clubStudent.StudentId = idService.GetId();

        //    db.Add(clubStudent);
        //    db.SaveChanges();
        //}

        [HttpGet]
        public void Test([FromServices] DatabaseContext db, IdService idService)
        {
            TClub club = new();
            club.Id =idService.GetId();

            club.Name = "足球社";
            club.Description = "青少年最喜歡的俱樂部";
            db.TClub.Add(club);
            db.SaveChanges();


            TClub club2 = new ();
            club.Id = idService.GetId();

            club.Name = "籃球社";
            club.Description = "青少年最喜歡的俱樂部";
            db.TClub.Add(club);
            db.SaveChanges();

            TMajor major = new TMajor();
            major.Id = idService.GetId();
            major.Name = "數學";
            major.Description = "微積分";
            db.TMajor.Add(major);
            db.SaveChanges();

            TTeacher teacher = new ();
            teacher.Id = idService.GetId();
            teacher.Name = "吳曉華";
            teacher.Phone = "097845123";
            teacher.Email = "456@gmail.com";
            teacher.MajorId = major.Id;
            db.TTeacher.Add(teacher);
            db.SaveChanges();



            TStudent student = new ();
            student.Id = idService.GetId();
            student.Name = "小白";
            student.Phone = "12457893";
            student.TeacherId=teacher.Id;
            student.MajorId = major.Id;

            db.TStudent.Add(student);
            db.SaveChanges();

            TClubStudent clubStudent = new ();
            clubStudent.Id = idService.GetId();
            clubStudent.ClubId = club.Id;
            clubStudent.StudentId = student.Id;
            db.TClubStudent.Add(clubStudent);
            db.SaveChanges();

        }


        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public string? GetPublicKey() => authorizeService.GetPublicKey();



        /// <summary>
        /// 获取Token认证信息
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public string? GetToken(DtoGetToken login) => authorizeService.GetToken(login);



        /// <summary>
        /// 通过微信小程序Code获取Token认证信息
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public string? GetTokenByWeiXinMiniApp([FromBody] DtoGetTokenByWeiXinApp login) => authorizeService.GetTokenByWeiXinMiniApp(login);



        /// <summary>
        /// 利用手机号和短信验证码获取Token认证信息
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public string? GetTokenBySMS(DtoGetTokenBySMS login) => authorizeService.GetTokenBySMS(login);



        /// <summary>
        /// 获取授权功能列表
        /// </summary>
        /// <param name="sign">模块标记</param>
        /// <returns></returns>
        [Authorize]
        [CacheDataFilter(TTL = 60, IsUseToken = true)]
        [HttpGet]
        public List<DtoKeyValue> GetFunctionList(string sign) => authorizeService.GetFunctionList(sign);



        /// <summary>
        /// 发送短信验证手机号码所有权
        /// </summary>
        /// <param name="sendVerifyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public bool SendSMSVerifyCode(DtoSendSMSVerifyCode sendVerifyCode) => authorizeService.SendSMSVerifyCode(sendVerifyCode);



        /// <summary>
        /// 通过微信App Code获取Token认证信息
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public string? GetTokenByWeiXinApp(DtoGetTokenByWeiXinApp login) => authorizeService.GetTokenByWeiXinApp(login);



        /// <summary>
        /// 通过老密码修改密码
        /// </summary>
        /// <param name="updatePassword"></param>
        /// <returns></returns>
        [Authorize]
        [QueueLimitFilter(IsBlock = true, IsUseParameter = false, IsUseToken = true)]
        [HttpPost]
        public bool UpdatePasswordByOldPassword(DtoUpdatePasswordByOldPassword updatePassword) => authorizeService.UpdatePasswordByOldPassword(updatePassword);



        /// <summary>
        /// 通过短信验证码修改账户密码</summary>
        /// <param name="updatePassword"></param>
        /// <returns></returns>
        [Authorize]
        [QueueLimitFilter(IsBlock = true, IsUseParameter = false, IsUseToken = true)]
        [HttpPost]
        public bool UpdatePasswordBySMS(DtoUpdatePasswordBySMS updatePassword) => authorizeService.UpdatePasswordBySMS(updatePassword);



        /// <summary>
        /// 生成密码
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpGet]
        public DtoKeyValue GeneratePassword(string passWord) => authorizeService.GeneratePassword(passWord);



        /// <summary>
        /// 更新路由信息表
        /// </summary>
        [HttpGet]
        public void UpdateRoute(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, DatabaseContext db, IdService idService)
        {
            var actionList = actionDescriptorCollectionProvider.ActionDescriptors.Items.Cast<ControllerActionDescriptor>().Select(x => new
            {
                Name = x.DisplayName![..(x.DisplayName!.IndexOf('(') - 1)],
                Route = x.AttributeRouteInfo!.Template,
                IsAuthorize = x.EndpointMetadata.Where(t => t.GetType().FullName == "Microsoft.AspNetCore.Authorization.AuthorizeAttribute").Any() == true && x.EndpointMetadata.Where(t => t.GetType().FullName == "Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute").Any() == false,
            }).ToList();

            string projectName = typeof(Program).Assembly.GetName().Name!;

            XmlDocument xml = new();
            xml.Load(AppContext.BaseDirectory + projectName + ".xml");
            XmlNodeList memebers = xml.SelectNodes("/doc/members/member")!;

            Dictionary<string, string> remarksDict = [];


            for (int c = 0; c < memebers.Count; c++)
            {
                var xmlNode = memebers[c];

                if (xmlNode != null)
                {
                    if (xmlNode.Attributes!["name"]!.Value.StartsWith("M:" + projectName + ".Controllers."))
                    {
                        for (int s = 0; s < xmlNode.ChildNodes.Count; s++)
                        {
                            var childNode = xmlNode.ChildNodes[s];

                            if (childNode != null && childNode.Name == "summary")
                            {
                                string name = xmlNode.Attributes!["name"]!.Value;

                                string summary = childNode.InnerText;

                                name = name![2..];

                                if (name.Contains('(', StringComparison.CurrentCulture))
                                {
                                    name = name[..name.IndexOf('(')];
                                }

                                summary = summary.Replace("\n", "").Trim();

                                remarksDict.Add(name, summary);
                            }
                        }
                    }
                }
            }


            actionList = actionList.Where(t => t.IsAuthorize == true).Distinct().ToList();


            var functionRoutes = db.TFunctionRoute.Where(t => t.Module == projectName).ToList();

            var delList = functionRoutes.Where(t => actionList.Select(t => t.Route).ToList().Contains(t.Route) == false).ToList();

            foreach (var item in delList)
            {
                item.IsDelete = true;
            }

            foreach (var item in actionList)
            {
                var info = functionRoutes.Where(t => t.Route == item.Route).FirstOrDefault();

                string? remarks = remarksDict.Where(a => a.Key == item.Name).Select(a => a.Value).FirstOrDefault();

                if (info != null)
                {
                    info.Remarks = remarks;
                }
                else
                {
                    TFunctionRoute functionRoute = new()
                    {
                        Id = idService.GetId(),
                        Module = projectName,
                        Route = item.Route!,
                        Remarks = remarks
                    };

                    db.TFunctionRoute.Add(functionRoute);
                }
            }

            db.SaveChanges();

        }

    }
}
