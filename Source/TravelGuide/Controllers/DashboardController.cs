using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using TravelGuide;

namespace eProject_3_Admin.Controllers
{
    public class DashboardController : Controller
    {

        TravelGuideDBContext db = new TravelGuideDBContext();
        #region Hotel
        // GET: Dashboard
        [HttpGet]
        public ActionResult Hotel(int? page, string searchString)
        {
            var restaurantList = new List<HOTEL>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                restaurantList = db.HOTELs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    restaurantList = restaurantList.Where(s => (s.NAME_HOTEL ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(restaurantList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult CreateHotel()
        {
            HOTEL model = new HOTEL();
            return View(model);
        } 
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateHotel(HOTEL hotel, HttpPostedFileBase fileUpload)
        {
            if(db.HOTELs.Any(x => x.ID_HOTEL == hotel.ID_HOTEL))
            {
                hotel.ID_HOTEL = db.HOTELs.Max(x => x.ID_HOTEL) + 1;
            }
            if (fileUpload == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hinh anh ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Message = "Image was existed ! Please choose another image.";
                    return View();

                }
                else
                {
                    //Luu hinh anh vao duong dan
                    fileUpload.SaveAs(path);
                    hotel.IMAGE_HOTEL = path;
                }

                try
                {
                    db.HOTELs.Add(hotel);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Hotel");
        }


        [HttpGet]
        public ActionResult EditHotel(int id)
        {
            //Lay doi tuong sanpham theo ma
            HOTEL hotel = db.HOTELs.SingleOrDefault(n => n.ID_HOTEL == id);
            if (hotel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hotel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditHotel(HOTEL hotel, HttpPostedFileBase fileUpload)
        {
            //var temp = db.SANPHAMs.SingleOrDefault(p => p.MaSP == sanpham.MaSP);
            //ViewBag.MaDM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TenDM), "MaDM", "TenDM", sanpham.MaDM);
            //if (fileUpload == null)
            //{
            //    TempData["msg"] = "<script>alert('Sửa thành công!');</script>";
            //    temp.Ngaycapnhat = DateTime.Now;
            //    UpdateModel(temp);
            //    db.SubmitChanges();
            //    return RedirectToAction("Sanpham");
            //}
            ////Them vao CSDL
            //else
            //{
            //    if (ModelState.IsValid)
            //    {
            //        //Luu ten file, luu y bo sung thu vien using System.IO;
            //        var fileName = Path.GetFileName(fileUpload.FileName);
            //        //Luu duong dan cua file
            //        var path = Path.Combine(Server.MapPath("~/images"), fileName);
            //        //Kiem tra hinh anh ton tai chua
            //        if (System.IO.File.Exists(path))
            //        {
            //            ViewBag.Thongbao = "Hình ảnh đã tồn tại";
            //        }
            //        else
            //        {
            //            //Luu hinh anh vao duong dan
            //            fileUpload.SaveAs(path);
            //        }
            //        temp.Hinhanh = fileName;
            //        temp.Ngaycapnhat = DateTime.Now;
            //        //Luu vao CSDL
            //        UpdateModel(temp);
            //        db.SubmitChanges();
            //        TempData["msg"] = "<script>alert('Sửa thành công!');</script>";
            //    }
            if (ModelState.IsValid)
            {
                try
                {
                    HOTEL model = db.HOTELs.Single(x=> x.ID_HOTEL == hotel.ID_HOTEL);
                    model.NAME_HOTEL = hotel.NAME_HOTEL; //ve them cac field con lai
                    //model = hotel;
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message});
                }
            }

            return RedirectToAction("Hotel");
        }

        [HttpGet]
        public ActionResult DeleteHotel(int id)
        {
            //Lay ra doi tuong san pham can xoa theo ma
            HOTEL hotel = db.HOTELs.SingleOrDefault(n => n.ID_HOTEL == id);
            if (hotel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hotel);
        }
        [HttpPost]
        public ActionResult DeleteHotel(int id,int? aaa)
        {
            try
            {
                HOTEL hotel = db.HOTELs.SingleOrDefault(n => n.ID_HOTEL == id);
                if (hotel == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.HOTELs.Remove(hotel);
                db.SaveChanges();
                return RedirectToAction("Hotel");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            //return View();
        }
        #endregion

        #region Resort
        [HttpGet]
        public ActionResult Resort(int? page, string searchString)
        {
            var restaurantList = new List<RESORT>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                restaurantList = db.RESORTs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    restaurantList = restaurantList.Where(s => (s.NAME_RESORT ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(restaurantList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult CreateResort()
        {
            RESORT model = new RESORT();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateResort(RESORT resort, HttpPostedFileBase fileUpload)
        {
            if (db.RESORTs.Any(x => x.ID_RESORT == resort.ID_RESORT))
            {
                resort.ID_RESORT = db.RESORTs.Max(x => x.ID_RESORT) + 1;
            }
            if (fileUpload == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hinh anh ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Message = "Image was existed ! Please choose another image.";
                    return View();
                }
                else
                {
                    //Luu hinh anh vao duong dan
                    fileUpload.SaveAs(path);
                    resort.IMAGE_RESORT = path;
                }

                try
                {
                    db.RESORTs.Add(resort);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Resort");
        }

        [HttpGet]
        public ActionResult EditResort(int id)
        {
            //Lay doi tuong sanpham theo ma
            RESORT resort = db.RESORTs.SingleOrDefault(n => n.ID_RESORT == id);
            if (resort == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownlist
            //Lay ds tu table phan khuc, sap xep tang dan theo ten phan khuc, chon lay gia tri MaDM, hien thi TenDM
            //ViewBag.MaDM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TenDM), "MaDM", "TenDM", sanpham.MaDM);
            return View(resort);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditResort(RESORT resort, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RESORT model = db.RESORTs.Single(x => x.ID_RESORT == resort.ID_RESORT);
                    model.NAME_RESORT = resort.NAME_RESORT; //ve them cac field con lai
                    //model = hotel;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            return RedirectToAction("Resort");
        }

        [HttpGet]
        public ActionResult DeleteResort(int id)
        {
            //Lay ra doi tuong san pham can xoa theo ma
            RESORT resort = db.RESORTs.SingleOrDefault(n => n.ID_RESORT == id);
            if (resort == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(resort);
        }
        [HttpPost]
        public ActionResult DeleteResort(int id, int? aaa)
        {
            try
            {
                RESORT resort = db.RESORTs.SingleOrDefault(n => n.ID_RESORT == id);
                if (resort == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.RESORTs.Remove(resort);
                db.SaveChanges();
                return RedirectToAction("Resort");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            //return View();
        }
        #endregion

        #region Restaurant
        [HttpGet]
        public ActionResult Restaurant(int? page, string searchString)
        {
            var restaurantList = new List<RESTAURANT>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                restaurantList = db.RESTAURANTs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    restaurantList = restaurantList.Where(s => (s.NAME_RESTAURANT ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(restaurantList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult CreateRestaurant()
        {
            RESTAURANT model = new RESTAURANT();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateRestaurant(RESTAURANT restaurant, HttpPostedFileBase fileUpload)
        {
            if (db.RESTAURANTs.Any(x => x.ID_RESTAURANT == restaurant.ID_RESTAURANT))
            {
                restaurant.ID_RESTAURANT = db.RESTAURANTs.Max(x => x.ID_RESTAURANT) + 1;
            }
            if (fileUpload == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hinh anh ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Message = "Image was existed ! Please choose another image.";
                    return View();
                }
                else
                {
                    //Luu hinh anh vao duong dan
                    fileUpload.SaveAs(path);
                    restaurant.IMAGE_RESTAURANT = path;
                }

                try
                {
                    db.RESTAURANTs.Add(restaurant);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Restaurant");
        }

        [HttpGet]
        public ActionResult EditRestaurant(int id)
        {
            //Lay doi tuong sanpham theo ma
            RESTAURANT restaurant = db.RESTAURANTs.SingleOrDefault(n => n.ID_RESTAURANT == id);
            if (restaurant == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownlist
            //Lay ds tu table phan khuc, sap xep tang dan theo ten phan khuc, chon lay gia tri MaDM, hien thi TenDM
            //ViewBag.MaDM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TenDM), "MaDM", "TenDM", sanpham.MaDM);
            return View(restaurant);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditRestaurant(RESTAURANT restaurant, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RESTAURANT model = db.RESTAURANTs.Single(x => x.ID_RESTAURANT == restaurant.ID_RESTAURANT);
                    model.NAME_RESTAURANT = restaurant.NAME_RESTAURANT; //ve them cac field con lai
                    model.ID_CITY = restaurant.ID_CITY;
                    model.ID_RESTAURANT = restaurant.ID_RESTAURANT;
                    model.IMAGE_RESTAURANT = restaurant.IMAGE_RESTAURANT;
                    model.INTRODUCE_RESTAURANT = restaurant.INTRODUCE_RESTAURANT;
                    model.QUALITY_RESTAURANT = restaurant.QUALITY_RESTAURANT;
                    model.TEL_RESTAURANT = restaurant.TEL_RESTAURANT;
                    model.DES_RESTAURANT = restaurant.DES_RESTAURANT;
                    model.AVAILABLE = restaurant.AVAILABLE;
                    //model = hotel;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            return RedirectToAction("Restaurant");
        }

        [HttpGet]
        public ActionResult DeleteRestaurant(int id)
        {
            //Lay ra doi tuong san pham can xoa theo ma
            RESTAURANT restaurant = db.RESTAURANTs.SingleOrDefault(n => n.ID_RESTAURANT == id);
            if (restaurant == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(restaurant);
        }
        [HttpPost]
        public ActionResult DeleteRestaurant(int id, int? aaa)
        {
            try
            {
                RESTAURANT restaurant = db.RESTAURANTs.SingleOrDefault(n => n.ID_RESTAURANT == id);
                if (restaurant == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.RESTAURANTs.Remove(restaurant);
                db.SaveChanges();
                return RedirectToAction("Restaurant");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            //return View();
        }
        #endregion

        #region Tourist_Spot
        [HttpGet]
        public ActionResult Tourist_Spots(int? page, string searchString)
        {
            var touristSpotsList = new List<TOURIST_SPOTS>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                touristSpotsList = db.TOURIST_SPOTS.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    touristSpotsList = touristSpotsList.Where(s => (s.NAME_TOURISTSPOT ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(touristSpotsList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult CreateTouristSpots()
        {
            TOURIST_SPOTS model = new TOURIST_SPOTS();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTouristSpots(TOURIST_SPOTS touristSpots, HttpPostedFileBase fileUpload)
        {
            if (db.TOURIST_SPOTS.Any(x => x.ID_TOURISTSPOT == touristSpots.ID_TOURISTSPOT))
            {
                touristSpots.ID_TOURISTSPOT = db.TOURIST_SPOTS.Max(x => x.ID_TOURISTSPOT) + 1;
            }
            if (fileUpload == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hinh anh ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Message = "Image was existed ! Please choose another image.";
                    return View();
                }
                else
                {
                    //Luu hinh anh vao duong dan
                    fileUpload.SaveAs(path);
                    touristSpots.IMAGE_TOURIST_SPOTS = path;
                }

                try
                {
                    db.TOURIST_SPOTS.Add(touristSpots);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Tourist_Spots");
        }

        [HttpGet]
        public ActionResult EditTouristSpots(int id)
        {
            //Lay doi tuong sanpham theo ma
            TOURIST_SPOTS touristSpots = db.TOURIST_SPOTS.SingleOrDefault(n => n.ID_TOURISTSPOT == id);
            if (touristSpots == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownlist
            //Lay ds tu table phan khuc, sap xep tang dan theo ten phan khuc, chon lay gia tri MaDM, hien thi TenDM
            //ViewBag.MaDM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TenDM), "MaDM", "TenDM", sanpham.MaDM);
            return View(touristSpots);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTouristSpots(TOURIST_SPOTS touristSpots, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TOURIST_SPOTS model = db.TOURIST_SPOTS.Single(x => x.ID_TOURISTSPOT == touristSpots.ID_TOURISTSPOT);
                    model.NAME_TOURISTSPOT = touristSpots.NAME_TOURISTSPOT;
                    model.ID_TOURISTSPOT = touristSpots.ID_TOURISTSPOT;
                    model.IMAGE_TOURIST_SPOTS = touristSpots.IMAGE_TOURIST_SPOTS;
                    model.INTRODUCE_TOURIST_SPOTS = touristSpots.INTRODUCE_TOURIST_SPOTS;
                    model.QUALITY_TOURISTSPOT = touristSpots.QUALITY_TOURISTSPOT;
                    model.TEL_TOURISTSPOT = touristSpots.TEL_TOURISTSPOT;
                    model.DES_TOURIST_SPOTS = touristSpots.DES_TOURIST_SPOTS;
                    model.ID_CITY = touristSpots.ID_CITY;
                    //model = hotel;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            return RedirectToAction("Tourist_Spots");
        }

        [HttpGet]
        public ActionResult DeleteTouristSpots(int id)
        {
            //Lay ra doi tuong san pham can xoa theo ma
            TOURIST_SPOTS touristSpots = db.TOURIST_SPOTS.SingleOrDefault(n => n.ID_TOURISTSPOT == id);
            if (touristSpots == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteTouristSpots(int id, int? aaa)
        {
            try
            {
                TOURIST_SPOTS touristSpots = db.TOURIST_SPOTS.SingleOrDefault(n => n.ID_TOURISTSPOT == id);
                if (touristSpots == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.TOURIST_SPOTS.Remove(touristSpots);
                db.SaveChanges();
                return RedirectToAction("Tourist_Spots");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            return View();
        }
        #endregion

        #region Travel
        [HttpGet]
        public ActionResult Travel(int? page, string searchString)
        {
            var travelList = new List<TRAVEL>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                travelList = db.TRAVELs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    travelList = travelList.Where(s => (s.NAME_TRAVEL ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(travelList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult CreateTravel()
        {
            TRAVEL model = new TRAVEL();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTravel(TRAVEL travel, HttpPostedFileBase fileUpload)
        {
            if (db.TRAVELs.Any(x => x.ID_TRAVEL == travel.ID_TRAVEL))
            {
                travel.ID_TRAVEL = db.TRAVELs.Max(x => x.ID_TRAVEL) + 1;
            }
            if (fileUpload == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hinh anh ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Message = "Image was existed ! Please choose another image.";
                    return View();
                }
                else
                {
                    //Luu hinh anh vao duong dan
                    fileUpload.SaveAs(path);
                    travel.IMAGE_TRAVEL = path;
                }

                try
                {
                    db.TRAVELs.Add(travel);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Travel");
        }

        [HttpGet]
        public ActionResult EditTravel(int id)
        {
            //Lay doi tuong sanpham theo ma
            TRAVEL travel = db.TRAVELs.SingleOrDefault(n => n.ID_TRAVEL == id);
            if (travel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownlist
            //Lay ds tu table phan khuc, sap xep tang dan theo ten phan khuc, chon lay gia tri MaDM, hien thi TenDM
            //ViewBag.MaDM = new SelectList(db.DANHMUCs.ToList().OrderBy(n => n.TenDM), "MaDM", "TenDM", sanpham.MaDM);
            return View(travel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTravel(TRAVEL travel, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TRAVEL model = db. TRAVELs.Single(x => x.ID_TRAVEL == travel.ID_TRAVEL);
                    model.NAME_TRAVEL = travel.NAME_TRAVEL; //ve them cac field con lai
                    model.ID_TRAVEL = travel.ID_TRAVEL;
                    model.IMAGE_TRAVEL = travel.IMAGE_TRAVEL;
                    model.INTRODUCE_TRAVEL = travel.INTRODUCE_TRAVEL;
                    model.QUALITY_TRAVEL = travel.QUALITY_TRAVEL;
                    model.TEL_TRAVEL = travel.TEL_TRAVEL;
                    model.DES_TRAVEL = travel.DES_TRAVEL;
                    model.ID_CITY = travel.ID_CITY;
                    //model = hotel;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            return RedirectToAction("Travel");
        }

        [HttpGet]
        public ActionResult DeleteTravel(int id)
        {
            //Lay ra doi tuong san pham can xoa theo ma
            TRAVEL travel = db.TRAVELs.SingleOrDefault(n => n.ID_TRAVEL == id);
            if (travel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(travel);
        }
        [HttpPost]
        public ActionResult DeleteTravel(int id, int? aaa)
        {
            try
            {
                TRAVEL travel = db.TRAVELs.SingleOrDefault(n => n.ID_TRAVEL == id);
                if (travel == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.TRAVELs.Remove(travel);
                db.SaveChanges();
                return RedirectToAction("Travel");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            //return View();
        }
        #endregion

        #region Admin
        [HttpGet]
        public ActionResult Admin(int? page, string searchString)
        {
            var adminList = new List<ADMIN>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                adminList = db.ADMINs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    adminList = adminList.Where(s => (s.NAME_ADMIN ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(adminList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            ADMIN model = new ADMIN();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateAdmin(ADMIN admin, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (db.ADMINs.Any(x => x.ID_ADMIN == admin.ID_ADMIN))
                {
                    admin.ID_ADMIN = db.ADMINs.Max(x => x.ID_ADMIN) + 1;
                }
                try
                {
                    db.ADMINs.Add(admin);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            ADMIN admin = db.ADMINs.SingleOrDefault(n => n.ID_ADMIN == id);
            if (admin == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(admin);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAdmin(ADMIN admin, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ADMIN model = db.ADMINs.Single(x => x.ID_ADMIN == admin.ID_ADMIN);
                    model.NAME_ADMIN = admin.NAME_ADMIN;
                    model.ID_ADMIN = admin.ID_ADMIN;
                    model.ADDRESS_ADMIN = admin.ADDRESS_ADMIN;
                    model.TEL_ADMIN = admin.TEL_ADMIN;
                    model.EMAIL_ADMIN = admin.EMAIL_ADMIN;
                    model.DISASBLE = admin.DISASBLE;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public ActionResult DeleteAdmin(int id)
        {
            //Lay ra doi tuong san pham can xoa theo ma
            ADMIN admin = db.ADMINs.SingleOrDefault(n => n.ID_ADMIN == id);
            if (admin == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(admin);
        }
        [HttpPost]
        public ActionResult DeleteAdmin(int id, int? aaa)
        {
            try
            {
                ADMIN admin = db.ADMINs.SingleOrDefault(n => n.ID_ADMIN == id);
                if (admin == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                db.ADMINs.Remove(admin);
                db.SaveChanges();
                return RedirectToAction("Admin");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            //return View();
        }
        #endregion

        #region User
        [HttpGet]
        public ActionResult User(int? page, string searchString)
        {
            var userList = new List<USERACCOUNT>();
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            try
            {
                userList = db.USERACCOUNTs.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    userList = userList.Where(s => (s.NAME_USER ?? "").ToLower().Contains(searchString)).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return View(userList.ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            USERACCOUNT user = db.USERACCOUNTs.SingleOrDefault(n => n.ID_USER == id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(user);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditUser(string ID_USER, bool DISASBLE, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    USERACCOUNT model = db.USERACCOUNTs.Single(x => x.ID_USER == ID_USER);
                    model.DISASBLE = DISASBLE;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new { msg = ex.Message });
                }
            }
            return RedirectToAction("User");
        }
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            ADMIN admim = new ADMIN();
            return View(admim);
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                var model = db.ADMINs.FirstOrDefault(x => x.NAME_ADMIN == username);
                if (model != null)
                {
                    if (model.DISASBLE == true)
                    {
                        ModelState.AddModelError("Password", "Account blocked. Please contact to admin.");
                    }
                    else if (model.PASS_ADMIN != password)
                    {
                        ModelState.AddModelError("Password", "Incorrect Password. Please enter password again.");
                    }
                    else
                    {
                        Session["Login"] = model.NAME_ADMIN;
                        return RedirectToAction("Hotel");
                    }
                }
                else
                {
                    ModelState.AddModelError("Account", "Incorrect Account. Please enter account again.");
                }
                

            }
            return View();
        }
        #endregion
    }
}
