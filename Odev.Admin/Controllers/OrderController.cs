using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderServices _orderServices;
        private readonly OrderItemServices _orderItemServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;
        private readonly CustomerAddressServices _customerAddressServices;
        private readonly SettingServices _settingsServices;
        private readonly CustomerServices _customerServices;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Detail";

        public OrderController()
        {
            _orderServices = new OrderServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
            _customerAddressServices = new CustomerAddressServices(_unitOfWork);
            _settingsServices = new SettingServices(_unitOfWork);
            _customerServices = new CustomerServices(_unitOfWork);
            _orderItemServices = new OrderItemServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.OrderTransactions)
                {
                    var orderDetailList = _orderServices.GetAll().OrderByDescending(x => x.CreatedDateTime);

                    return View(ViewList, orderDetailList);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public async Task<ActionResult> StatusUpdate(Guid id, string trackingNumber)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubOrderTransactions)
                {
                    if (string.IsNullOrEmpty(trackingNumber))
                    {
                        _orderServices.UpdateOrderStatusPacked(id);
                        _unitOfWork.SaveChanges();
                    }
                    else if (!string.IsNullOrEmpty(trackingNumber))
                    {
                        _orderServices.UpdateOrderStatusShipped(id, trackingNumber);
                        _unitOfWork.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Detail(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubOrderTransactions)
                {
                    var orderDetail = _orderServices.Get(id);
                    orderDetail.OrderItems = _orderItemServices.GetAllByOrderId(id).ToList();
                    orderDetail.OrderShippingAddress = _customerAddressServices.Get(orderDetail.OrderShippingAddressId);
                    orderDetail.OrderBillingAddress = _customerAddressServices.Get(orderDetail.OrderBillingAddressId);

                    return View(ViewForm, orderDetail);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public async Task<ActionResult> OrderCanceled(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubOrderTransactions)
                {
                    // Todo: Order İptal işlemi yapılacak. Ücret iadesi ve statü cancel çekilecek

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}