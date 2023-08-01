using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;

namespace PRN221_Project1._0.Pages
{
    public class ManageSessionModel : PageModel
    {
        IGroupRepository groupRepository;
        ISessionRepository sessionRepository;
        ILectureRepository lectureRepository;
        ISlotRepository slotRepository;
        IRoomRepository roomRepository;
        public List<SessionDTO> sessions { get; set; }
        public List<GroupDTO> groups { get; set; }
        public List<LectureDTO> lectures { get; set; }
        public List<SlotDTO> slots { get; set; }
        public List<RoomDTO> rooms { get; set; }
        public int groupId { get; set; }

        public ManageSessionModel(IGroupRepository groupRepository, ISessionRepository sessionRepository, ILectureRepository lectureRepository, ISlotRepository slotRepository, IRoomRepository roomRepository)
        {
            this.groupRepository = groupRepository;
            this.sessionRepository = sessionRepository;
            this.lectureRepository = lectureRepository;
            this.slotRepository = slotRepository;
            this.roomRepository = roomRepository;
        }
        public IActionResult OnGet(int? groupId)
        {
            string wsadmin = HttpContext.Session.GetString("admin");
            string json = HttpContext.Session.GetString("lecture");
            if (wsadmin == null && json == null)
            {
                // Redirect the user to the login page
                return RedirectToPage("/Login");
            }
            if (json != null)
            {
                return RedirectToPage("/Timetable");

            }
            slots = slotRepository.GetSlots();
            groups = groupRepository.GetAllGroups();
            rooms = roomRepository.GetRooms();
            if (groupId.HasValue)
            {
                sessions = sessionRepository.GetSessionsOfGroup(groupId.Value);
                this.groupId = groupId.Value;
            }
            return Page();
        }
        public IActionResult OnPostCreateSession()
        {
            int groupId = Int32.Parse(HttpContext.Request.Form["groupId"]);
            DateTime date = DateTime.Parse(HttpContext.Request.Form["date"]);
            int slotId = Int32.Parse(HttpContext.Request.Form["slot"]);
            int roomId = Int32.Parse(HttpContext.Request.Form["room"]);
            LectureDTO lectureDTO = groupRepository.GetLecture(groupId);
            if (sessionRepository.CreateSession(groupId, date, slotId, roomId, lectureDTO.LectureId))
            {
                TempData["messageResponse"] = "Add success";

            }
            else
            {
                TempData["messageResponse"] = "Add fail. This session is duplicated!";

            }
            return RedirectToPage();
        }
    }
}
