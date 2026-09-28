using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab.Problems.Builder;
public class CourseRegistrationBuilder
{
    private string? _studentEmail;
    private string? _courseCode;
    private string? _accessMode;
    private string? _groupCode;

    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;
    public CourseRegistrationBuilder ForStudent(string email)
    {
        _studentEmail = email;
          return this;
    }

    public CourseRegistrationBuilder ForCourse(string code)
    {
        _courseCode = code;
         return this;
    }

    public CourseRegistrationBuilder LiveGroup(string groupCode)
    {
        _accessMode = "LiveGroup";
        _groupCode = groupCode;
         return this;
    }
    public CourseRegistrationBuilder VideosOnly()
    {
        _accessMode = "VideosOnly";
        return this;
    }
    public CourseRegistrationBuilder WithDiscount(string code)
    {
        _discountCode = code;
        return this;
    }
    public CourseRegistrationBuilder SendWhatsApp()
    {
        _sendWhatsApp = true;
        return this;
    }

    public CourseRegistrationBuilder SendEmailWelcome()
    {
        _sendEmailWelcome = true;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string note)
    {
        _mentorNote = note;
        return this;
    }

    public CourseRegistrationBuilder StartingOn(DateOnly date)
    {
        _preferredStart = date;
        return this;
    }


    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_studentEmail))
            throw new ArgumentException("email required");

        if (string.IsNullOrWhiteSpace(_courseCode))
            throw new ArgumentException("course required");

        if (string.IsNullOrWhiteSpace(_accessMode))
            throw new InvalidOperationException("access mode required");

        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");

        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart);
    }
}
