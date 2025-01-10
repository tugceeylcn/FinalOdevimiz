using FluentFTP;
using FluentValidation;
using FluentValidation.Results;
using Odev.DAL.UnitOfWork;
using Odev.Domain.Environments;
using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class BaseController : Controller
    {
        public readonly OdevUnitOfWork _unitOfWork;
        private readonly UserTypeServices _userTypeServices;
        public UserViewModel _user;
        private readonly SettingServices _settingsServices;

        public BaseController()
        {
            _unitOfWork = new OdevUnitOfWork();
            _userTypeServices = new UserTypeServices(_unitOfWork);
            ViewBag.UserType = _userTypeServices.GetAll().ToList();

            _settingsServices = new SettingServices(_unitOfWork);
            ViewBag.Setting = _settingsServices.GetAll().FirstOrDefault();
        }

        public UserViewModel SessionKontrol()
        {
            _user = (UserViewModel)Session["user"];
            return _user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValidator"></typeparam>
        /// <param name="model">ViewModel -> ViewModel Gönder</param>
        /// <param name="validator">yazılan validator ı gönder </param>
        /// <param name="modelState">view den gelen bilgileri gönder</param>
        /// <returns></returns>
        public bool Validate<TModel, TValidator>(TModel model, TValidator validator, ModelStateDictionary modelState)
          where TValidator : AbstractValidator<TModel>
        {
            ValidationResult result = validator.Validate(model);

            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return result.IsValid;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session["user"];
            if (session == null)
            {
                Response.Redirect("/Login/");
            }


            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            base.OnActionExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {

            foreach (var item in filterContext.RouteData.Values)
            {
                if (item.Key == "id")
                {
                    var id = Guid.Parse(item.Value.ToString());
                    if (id != Guid.Empty)
                    {
                        Response.Redirect("/Dashboard/");
                        return;
                    }
                }
            }

            StreamWriter logYaz = System.IO.File.AppendText(Server.MapPath("~/Assets/log/log.txt"));
            logYaz.WriteLine($@"
                Hata:
                {filterContext.Exception}
                =========================
                Hata Tarihi : {DateTime.Now}
                =========================
                ");
            logYaz.Flush();
            logYaz.Close();
            logYaz.Dispose();


            base.OnException(filterContext);
        }

        public string ImageUpload(HttpPostedFileBase image)
        {
            string fileName = null;

            //FluentFTP kullanıldı
            if (image != null)
            {
                var extension = Path.GetExtension(image.FileName);
                fileName = Guid.NewGuid() + extension;
                var localPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                image.SaveAs(localPath); // Yedek resim admin panelinde de saklanıyor

                string ftpRemotePath = $"{Globals.ftpRemotePath}{fileName}"; // FTP'de dosyanın yükleneceği yol

                using (var ftpClient = new FtpClient(Globals.ftpServer, Globals.ftpUsername, Globals.ftpPassword))
                {
                    try
                    {
                        ftpClient.Connect();
                        var asd = ftpClient.UploadFile(localPath, ftpRemotePath);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        ftpClient.Disconnect();
                    }
                }
            }

            return fileName;
        }
    }
}