using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class ShoppingController : BaseController
    {
        private readonly SettingServices _settingsServices;
        private readonly ShoppingCartServices _shoppingCartServices;
        private readonly ShoppingCartItemServices _shoppingCartItemServices;
        private readonly CustomerAddressServices _customerAddressServices;
        private readonly CustomerServices _customerServices;
        private readonly ProductServices _productServices;
        private readonly OrderServices _orderServices;
        private readonly OrderItemServices _orderItemServices;

        public ShoppingController()
        {
            _settingsServices = new SettingServices(_unitOfWork);
            _shoppingCartServices = new ShoppingCartServices(_unitOfWork);
            _shoppingCartItemServices = new ShoppingCartItemServices(_unitOfWork);
            _customerAddressServices = new CustomerAddressServices(_unitOfWork);
            _customerServices = new CustomerServices(_unitOfWork);
            _productServices = new ProductServices(_unitOfWork);
            _orderServices = new OrderServices(_unitOfWork);
            _orderItemServices = new OrderItemServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    var setting = _settingsServices.GetAll().FirstOrDefault();

                    var model = _shoppingCartServices.GetByCustomerId(_customer.Id);
                    model.ShoppingCartItems = new List<ShoppingCartItemViewModel>();
                    if (model != null)
                    {
                        model.ShoppingCartItems = _shoppingCartItemServices.GetByShoppingCartId(model.Id).ToList();

                        model.CargoCampaign = model.ShoppingCartItems.Sum(x => x.Quantity * x.OrderItemPriceInclTax) > Convert.ToInt32(setting.CargoCampaign);
                        if (!model.CargoCampaign.Value)
                        {
                            model.BasketTaxTotal += setting.CargoPrice;
                        }
                    }

                    return View(model);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveShoppingCartItem(Guid id)
        {
            string referrerUrl = Request.UrlReferrer?.ToString();
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    _shoppingCartItemServices.Delete(id);
                    _unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(referrerUrl) && Url.IsLocalUrl(referrerUrl))
                    {
                        return Redirect(referrerUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home"); // Default yönlendirme
                    }
                }
            }

            if (!string.IsNullOrEmpty(referrerUrl) && Url.IsLocalUrl(referrerUrl))
            {
                return Redirect(referrerUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home"); // Default yönlendirme
            }
        }

        public JsonResult AddToCart(Guid productId, int quantity = 1)
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    var product = _productServices.Get(productId);
                    var shoppingCart = _shoppingCartServices.GetByCustomerId(_customer.Id);
                    var orderItemDiscount = product.ProductFirstPrice > 0 ? product.ProductFirstPrice - product.ProductPrice : 0;

                    if (shoppingCart != null)
                    {
                        var checkShoppingCartItem = _shoppingCartItemServices.CheckShoppingCartItemByProduct(productId, Guid.Parse("DF3FC3D7-EFEA-416B-9760-19BECC061EA3"), shoppingCart.Id);

                        if (checkShoppingCartItem != null || checkShoppingCartItem != default)
                        {
                            checkShoppingCartItem.Quantity += quantity;
                            checkShoppingCartItem.UpdatedDateTime = DateTime.Now;

                            _shoppingCartItemServices.Update(checkShoppingCartItem);
                            _unitOfWork.SaveChanges();
                        }
                        else
                        {
                            var cartItemViewModel = new ShoppingCartItemViewModel
                            {
                                ColorId = Guid.Parse("DF3FC3D7-EFEA-416B-9760-19BECC061EA3"),
                                CampaignCodeKey = "",
                                Language = Domain.Enums.LanguageSelection.TR,
                                OrderItemDiscount = orderItemDiscount,
                                OrderItemPriceInclTax = product.ProductPrice,
                                ProductId = productId,
                                Quantity = quantity,
                                ShoppingCartId = shoppingCart.Id,
                                UsedGiftCardPointPriceAmount = 0,
                                ProductCategoryTitle = product.CategoryName,
                                ProductTitle = product.ProductName,
                                ProductSlug = product.Slug,
                                PictureImage = product.ProductCoverImage,
                                IsActive = product.IsActive,
                                IsDeleted = product.IsDeleted,
                                Id = product.Id
                            };

                            _shoppingCartItemServices.Add(cartItemViewModel);
                            _unitOfWork.SaveChanges();
                        }
                    }
                    else
                    {
                        var shoppingCartViewModel = new ShoppingCartViewModel
                        {
                            CustomerId = _customer.Id,
                            IsCodeOrCopunEnabled = false,
                            UsedGiftCardAmount = 0,
                            UsedCodeOrCoupon = null,
                            IsGiftCardEnabled = false,
                            CargoId = Guid.Parse("7762967F-027A-4915-9FEE-962CE6736186"),
                            OrderOrderTypeId = Guid.Empty,
                            PaymentTypeId = Guid.Empty,
                            BasketTaxTotal = 0,
                            GetCargoOnDeliveryInclTax = Convert.ToDecimal(29),
                            GetShoppingCartItemTotalQuantity = 0,

                        };

                        var shoppingCartId = _shoppingCartServices.Add(shoppingCartViewModel);
                        _unitOfWork.SaveChanges();

                        var shoppingCartItemViewModels = new List<ShoppingCartItemViewModel>();

                        var cartItemViewModel = new ShoppingCartItemViewModel
                        {
                            ColorId = Guid.Parse("DF3FC3D7-EFEA-416B-9760-19BECC061EA3"),
                            CampaignCodeKey = "",
                            Language = Domain.Enums.LanguageSelection.TR,
                            OrderItemDiscount = orderItemDiscount,
                            OrderItemPriceInclTax = product.ProductPrice,
                            ProductId = productId,
                            Quantity = quantity,
                            ShoppingCartId = shoppingCartId,
                            UsedGiftCardPointPriceAmount = 0,
                            ProductCategoryTitle = product.CategoryName,
                            ProductTitle = product.ProductName,
                            ProductSlug = product.Slug,
                            PictureImage = product.ProductCoverImage,
                            IsActive = product.IsActive,
                            IsDeleted = product.IsDeleted,
                            Id = product.Id
                        };

                        shoppingCartItemViewModels.Add(cartItemViewModel);
                        _shoppingCartItemServices.Add(cartItemViewModel);
                        _unitOfWork.SaveChanges();

                        shoppingCartViewModel.BasketTaxTotal = (decimal)shoppingCartItemViewModels.Sum(x => x.Quantity * x.OrderItemPriceInclTax);
                        shoppingCartViewModel.GetShoppingCartItemTotalQuantity = shoppingCartItemViewModels.Sum(x => x.Quantity);

                        _shoppingCartServices.Update(shoppingCartViewModel);
                        _unitOfWork.SaveChanges();
                    }

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddressSet(Guid addressId)
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    var shoppingCart = _shoppingCartServices.GetByCustomerId(_customer.Id);

                    if (shoppingCart != null)
                    {
                        shoppingCart.AddressId = addressId;

                        _shoppingCartServices.Update(shoppingCart);
                        _unitOfWork.SaveChanges();
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delivery()
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    var setting = _settingsServices.GetAll().FirstOrDefault();

                    var model = _shoppingCartServices.GetByCustomerId(_customer.Id);
                    if (model != null)
                    {
                        model.ShoppingCartItems = _shoppingCartItemServices.GetByShoppingCartId(model.Id).ToList();
                        model.CargoCampaign = model.ShoppingCartItems.Sum(x => x.Quantity * x.OrderItemPriceInclTax) > Convert.ToInt32(setting.CargoCampaign);
                        if (!model.CargoCampaign.Value)
                        {
                            model.BasketTaxTotal += setting.CargoPrice;
                        }

                        var customerAddress = _customerAddressServices.GetAllByCustomerId(_customer.Id).ToList();

                        return View(customerAddress);
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Payment()
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    var setting = _settingsServices.GetAll().FirstOrDefault();

                    var model = _shoppingCartServices.GetByCustomerId(_customer.Id);
                    if (model != null)
                    {
                        model.ShoppingCartItems = _shoppingCartItemServices.GetByShoppingCartId(model.Id).ToList();
                        model.CargoCampaign = model.ShoppingCartItems.Sum(x => x.Quantity * x.OrderItemPriceInclTax) > Convert.ToInt32(setting.CargoCampaign);
                        if (!model.CargoCampaign.Value)
                        {
                            model.BasketTaxTotal += setting.CargoPrice;
                        }

                        if (model.AddressId == null || model.AddressId == Guid.Empty)
                        {
                            return RedirectToAction("Delivery", "Shopping");
                        }

                        return View();
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> DoTransactionCreditCard(PaymentCreditCartViewModel viewModel)
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    var orderId = Guid.NewGuid();
                    var conversationId = Guid.NewGuid();

                    var setting = _settingsServices.GetAll().FirstOrDefault();
                    var shoppingCart = _shoppingCartServices.GetByCustomerId(_customer.Id);

                    if (shoppingCart == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    var shoppingCartItems = _shoppingCartItemServices.GetByShoppingCartId(shoppingCart.Id).ToList();

                    if (shoppingCartItems == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    var customer = _customerServices.Get(_customer.Id);
                    var customerAddress = _customerAddressServices.Get(shoppingCart.AddressId);

                    if (customerAddress == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    // Ödeme İşlemleri yapılması lazım
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Ödeme İşleminde bir hata gerçekleşti. Lütfen daha sonra tekrar deneyiniz." });
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Summary(Guid id)
        {
            SessionKontrol();
            if (_customer != null)
            {
                try
                {
                    if (id == Guid.Empty || id == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    var model = _orderServices.Get(id);
                    if (model == default)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return View("Summary", model);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}