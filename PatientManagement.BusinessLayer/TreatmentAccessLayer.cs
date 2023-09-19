using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.BusinessLayer
{
    public static class TreatmentAccessLayer
    {
        public static ApplicationDbContext context;

        /// <summary>
        /// Returns Treatment list where the currently logged in user is the primary care provider.
        /// </summary>
        /// <returns></returns>
        public static List<TreatmentDto>? GetTreatmentList()
        {
            try
            {
                //var context = new ApplicationDbContext().GetContext();

                //Medication query could also be here bc linq queries are called when they're needed 
                //Treatments where the logged in user is the primary care provider 
                return context.Set<Treatment>().Where(x => x.Login.Username == LoginAccessLayer.username)
                    .Select(x => new TreatmentDto
                    {
                        Date = x.Date.ToShortDateString(),
                        Firstname = x.People.FirstName,
                        Lastname = x.People.LastName,
                        PatientId = x.PersonId,
                        Medication = context.Set<TreatmentArticle>().Where(y => y.TreatmentId == x.Id).Single().Article.Name,
                        Memo = x.Memo
                    }).ToList();
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return null;
            }
        }

        /// <summary>
        /// Returns Lists of Treatments with patient names that contain the search keyword in either their first or last name.
        /// </summary>
        /// <param name="search">Search Keyword.</param>
        /// <returns></returns>
        public static List<TreatmentDto>? GetTreatmentList(string search)
        {
            try
            {
                //Treatments where the logged in user is the doc and the patient's name contains search keyword
                return context.Set<Treatment>().Where(x => x.Login.Username == LoginAccessLayer.username && x.People.FirstName.Contains(search) || x.People.LastName.Contains(search))
                    .Select(x => new TreatmentDto
                    {
                        Date = x.Date.ToShortDateString(),
                        Firstname = x.People.FirstName,
                        Lastname = x.People.LastName,
                        PatientId = x.PersonId,
                        Medication = context.Set<TreatmentArticle>().Where(y => y.TreatmentId == x.Id).Single().Article.Name,
                        Memo = x.Memo
                    }).ToList();
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return null;
            }
        }

        /// <summary>
        /// Get medDto previously given to a certain Patient.
        /// </summary>
        /// <param name="PatientId">Id of the Patient.</param>
        /// <returns></returns>
        public static List<MedicationDto>? GetMedicationList(int PatientId)
        {
            try
            {
                //Medications given to Patient in the past
                return context.Set<TreatmentArticle>().Where(x => x.Treatment.PersonId == PatientId)
                                                      .Select(y => new MedicationDto
                                                      {
                                                          Name = y.Article.Name,
                                                          Date = y.Treatment.Date.ToShortDateString(),
                                                          Quantity = y.Quantity
                                                      }).ToList();
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all the medications listed in the Db.
        /// </summary>
        /// <returns></returns>
        public static List<String>? GetMedicationList()
        {
            try
            {
                List<string> medication = new List<string>();

                foreach (var article in context.Set<Article>().Select((x => x.Name)))
                {
                    medication.Add(article);
                }
                return medication;
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return null;
            }
        }
        /// <summary>
        /// Gets Patients and returns them as an array.
        /// </summary>
        /// <returns></returns>
        public static string[]? GetPatientsArray()
        {
            try
            {
                return context.Set<Person>().Select(x => $"{x.FirstName} {x.LastName}").ToArray();
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return null;
            }
        }

        /// <summary>
        /// Adds appointment to datebase.
        /// </summary>
        /// <param name="treatDto"></param>
        /// <returns></returns>
        public static bool AddAppointment(TreatmentDto treatDto)
        {
            try
            {   //Assign
                Person person = context.Set<Person>().Where(x => x.Id == treatDto.PatientId).Single();
                Login user = context.Set<Login>().Where(x => x.Id == LoginAccessLayer.userId).Single();
                Article article = context.Set<Article>().Where(x => x.Name == treatDto.Medication).Single();
                Treatment treatment = new()
                {
                    Date = Convert.ToDateTime(treatDto.Date).Date,
                    LoginId = person.Id,
                    Memo = treatDto.Memo,
                    PersonId = person.Id,
                    People = person,
                    Login = user
                };
                
                TreatmentArticle treatmentArticle = new()
                {
                    Article = article,
                    ArticleId = article.Id,
                    Quantity = 1,
                    Treatment = treatment,
                    TreatmentId = treatment.Id
                };

                //Add new entries to respective tables
                context.AddRange(treatment, treatmentArticle);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return false;
            }
        }

    }

    #region Data Transfer Objects
    public class TreatmentDto
    {
        public int PatientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Date { get; set; }
        public string Memo { get; set; }
        public string Medication { get; set; }
    }

    public class MedicationDto
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
    }

    #endregion
}
