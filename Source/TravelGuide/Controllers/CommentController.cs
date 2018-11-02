using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelGuide.Controllers
{
    public class CommentController : Controller
    {
        TravelGuideDBContext dBContext = new TravelGuideDBContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadComment(int? hotelId, int? restaurantId, int? resortId, int? travelId, int? touristId)
        {
            var comment = from c in dBContext.COMMENTs
                          select c;
            if (hotelId != null)
            {
                comment = comment.Where(s => s.ID_HOTEL == hotelId);
            }
            else if (restaurantId != null)
            {
                comment = comment.Where(s => s.ID_RESTAURANT== restaurantId);
            }
            else if (resortId != null)
            {
                comment = comment.Where(s => s.ID_RESORT == resortId);
            }
            else if (travelId != null)
            {
                comment = comment.Where(s => s.ID_TRAVEL == travelId);
            }
            else if (touristId != null)
            {
                comment = comment.Where(s => s.ID_TOURISTSPOT== touristId);
            }
            List<COMMENT> lstCommentDB = comment.ToList();
            List<COMMENT> lstComment = new List<COMMENT>();

            for (int i = 0; i < lstCommentDB.Count -1; i++)
            {
                string idCurrent = lstCommentDB[i].ID_COMMENT;
                if (lstCommentDB[i].ID_REPLY == null)
                {
                    lstComment.Add(lstCommentDB[i]);
                }
                for (int j = i + 1; j < lstCommentDB.Count; j++)
                {
                    if (lstCommentDB[j].ID_REPLY == idCurrent)
                    {
                        lstComment.Add(lstCommentDB[j]);
                    }
                } 
            }
           
            return View(lstComment);
        }

        public ActionResult AddComment (int? hotelId, int? restaurantId, int? resortId, 
            int? travelId, int? touristId, string contentComment, string id_user, bool? flag_reply, string id_reply)
        {
            COMMENT newCommnent = new COMMENT();
            newCommnent.ID_COMMENT = Guid.NewGuid().ToString("N");
            newCommnent.ID_HOTEL = hotelId;
            newCommnent.ID_RESTAURANT = restaurantId;
            newCommnent.ID_RESORT = resortId;
            newCommnent.ID_TRAVEL = travelId;
            newCommnent.ID_TOURISTSPOT = touristId;
            newCommnent.CONTENT_COMMENT = contentComment;
            newCommnent.ID_USER = id_user;
            newCommnent.FLAG_REPLY = flag_reply;
            newCommnent.ID_REPLY = id_reply;
            newCommnent.DT_COMMENT = DateTime.Now;
            dBContext.COMMENTs.Add(newCommnent);
            dBContext.SaveChanges();
            return RedirectToAction("LoadComment", "Comment");
        }
    }
}