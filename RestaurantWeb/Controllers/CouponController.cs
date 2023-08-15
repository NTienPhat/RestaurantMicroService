using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantWeb.Models;
using RestaurantWeb.Service.IService;
using System.Collections.Generic;

namespace RestaurantWeb.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            List <CouponDTO>? list = new();
            ResponseDTO? response = await _couponService.GetAllAsync();
            if(response != null)
            {
                list = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponDTO couponDTO)
        {
            if(ModelState.IsValid)
            {
                ResponseDTO? response = await _couponService.CreateAsync(couponDTO);
                if (response != null)
                {
					TempData["success"] = "Created successfully";
					return RedirectToAction(nameof(Index));
                }
                else
                {
					TempData["error"] = response?.Message;
				}
			}
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDTO? response = await _couponService.GetByIdAsync(id);
            if(response != null && response.IsSuccess)
            {
                CouponDTO? model = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
				TempData["error"] = response?.Message;
			}
			return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDTO coupon)
        {
            ResponseDTO? response = await _couponService.DeleteAsync(coupon.CouponId);
            if (response != null && response.IsSuccess)
            {
				TempData["success"] = "Deleted successfully";
				return RedirectToAction(nameof(Index));
            }
            else
            {
				TempData["error"] = response?.Message;
			}
			return View(coupon);
        }
    }
}
