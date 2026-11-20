using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab.Problems.Builder;
public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudent()
    {
        return new CourseRegistrationBuilder()
            .ForStudent("sara@mail.com")
            .ForCourse("SEF-101")
            .LiveGroup("G1")
            .WithDiscount("EARLY10")
            .SendWhatsApp()
            .SendEmailWelcome()
            .WithMentorNote("Needs evening slot")
            .StartingOn(new DateOnly(2026, 10, 1))
            .Build();
    }

    public static CourseRegistration CreateVideosOnly()
    {
        return new CourseRegistrationBuilder()
             .ForStudent("ali@mail.com")
             .ForCourse("SEF-101")
             .VideosOnly()
             .SendEmailWelcome()
             .Build();
    }
}
