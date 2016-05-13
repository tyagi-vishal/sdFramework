using Allevasoft.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allevasoft.Entities
{
    public partial class Opportunities
    {
        public int SalesOpp  { get; set; }
        public int PychOpp { get; set; }
        public int BillingOpp { get; set; }

        public int CostOpp { get; set; }
    }
    public partial class ClientStatus
    {
        /*Declare @StatusGreen int 
	Declare @StatusYellow int
	Declare @StatusRed int*/
        public int StatusGreen { get; set; }
        public int StatusYellow { get; set; }
        public int StatusRed { get; set; }
    }
    //--DischargeStatus
    //Declare @DischargeToday int
    //Declare @DischargeWeekly int
    //Declare @DischargeMonthly int
    public partial class DischargeStatus
    {
        public int DischargeToday { get; set; }
        public int DischargeWeekly { get; set; }
        public int DischargeMonthly { get; set; }

    }
    //--Bed Status

    //Declare @TotalBed int
    //Declare @AvailableBed int
    public partial class BedStatus
    {
        public int TotalBed { get; set; }
        public int AvailableBed { get; set; }
    }
    //--Appoinment status

    //Declare @AppointmentText varchar(max)

    //Declare @AppointmentTextTime varchar(100)
    public partial class AppointmentStatus
    {
        public string AppointmentText { get; set; }
        public string AppointmentTextTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
    //--Notes
    //Declare @NotesTo varchar(200)
    //Declare @NotesFrom varchar(200)
    //Declare @NotesContent varchar(max)
    //Declare @NotesCreatedDate varchar(100)
    //Declare @NotesTimeDifference varchar(100)
    public partial class Notes
    {
        public string NotesTo { get; set; }
        public string NotesFrom { get; set; }
        public string NotesContent { get; set; }
        public string NotesCreatedDate { get; set; }
        public string NotesTimeDifference { get; set; }

    }
    //--Messages
    //Declare @MessagesFrom varchar(200)
    //Declare @MessagesContent varchar(max)
    //Declare @MessagesTimeDifference varchar(100)
    public partial class Messages
    {
        public string ProfileImgUrl { get; set; }
        public string MessagesFrom { get; set; }
        public string MessagesContent { get; set; }
        public string MessagesTimeDifference { get; set; }
    }
    //--Alerts
    //Declare @AlertContent varchar(max)

    //Declare @AlertTimeDifference varchar(200)
    public partial class AlertsMessages
    {
        public string AlertContent { get; set; }
        public string AlertTimeDifference { get; set; }
    }
    public partial class CRMDeatials
    {
        public List<ssp_GetCRMDashbordDatails_Result> _Leads { get; set; }
        public List<Opportunities> _Oppertunities { get; set; }
        public List<AppointmentStatus> _Appointments { get; set; }
        public List<ClientStatus> _ClientStatus { get; set; }
        public List<DischargeStatus> _DischargeStatus { get; set; }
        public List<BedStatus> _BedStatus { get; set; }
        public List<Notes> _Notes { get; set; }
        public List<Messages> _Messages { get; set; }
        public List<AlertsMessages> _AlertsMessages { get; set; }
       
    }
}
