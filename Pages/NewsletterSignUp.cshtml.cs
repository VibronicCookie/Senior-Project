using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Senior_Project.Models;
using System.Net;
using System.Net.Mail;

namespace Senior_Project.Pages
{
    public class NewsletterSignUpModel : PageModel
    {
        private readonly EmailSettings _emailSettings;

        public NewsletterSignUpModel(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public string Message { get; set; }
        [BindProperty]
        public Recruit recruit { get; set; }

        public IActionResult OnPostAsync()
        {
            //try
            //{
            //    MailMessage msg = new MailMessage();
            //    msg.From = new MailAddress(_emailSettings.Username);
            //    msg.To.Add(new MailAddress(_emailSettings.Username));
            //    msg.Subject = "Recruit";
            //    msg.Body = recruit.fname + " " + recruit.lname + Environment.NewLine + recruit.email + Environment.NewLine + "Graduation Year: " + recruit.gradyear + Environment.NewLine + "Highschool: " + recruit.highschool + Environment.NewLine + "Additional Notes: " + recruit.notes;

            //    SmtpClient smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort);
            //    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_emailSettings.Username, _emailSettings.Password);
            //    smtpClient.Credentials = credentials;
            //    smtpClient.EnableSsl = true;
            //    smtpClient.Send(msg);

            //    return RedirectToPage("./Index");
            //}
            //catch (Exception)
            //{
            //    return RedirectToPage("./Index");
            //}
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_emailSettings.Username);
            msg.To.Add(new MailAddress(_emailSettings.Username));
            msg.Subject = "Recruit";
            msg.Body = recruit.fname + " " + recruit.lname + Environment.NewLine + recruit.email + Environment.NewLine + "Graduation Year: " + recruit.gradyear + Environment.NewLine + "Highschool: " + recruit.highschool + Environment.NewLine + "Additional Notes: " + recruit.notes;

            SmtpClient smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_emailSettings.Username, _emailSettings.Password);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);

            return RedirectToPage("./Success");
        }
    }
}