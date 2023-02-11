using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes.client
{
    [Table("Client")]
    public class DBClient
    {
        [Key]
        public string id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string midle_name { get; set; }

        public DateTime birthday { get; set; }
        public bool sex { get; set; }
        public string passport_series { get; set; }
        public string passport_number { get; set; }
        public string authority { get; set; }
        public DateTime date_of_issue { get; set; }
        public string? place_of_birth { get; set; }
        public string? mobile_phone { get; set; }
        public string? home_phone { get; set; }
        public string? e_mail { get; set; }
        public string? work_place { get; set; }
        public string? work_position { get; set; }
        public string address_of_registration { get; set; }
        public bool retired { get; set; }

        public decimal monthly_income { get; set; }

        public bool military_conscription { get; set; }


    }

    public class Client : DBClient
    {

        public List<City> live { get; set; }
        public List<City> residence { get; set; }
        public List<FamilyStatus> familyStatus { get; set; }
        public List<Disabilities> disabilities { get; set; }
        public List<Citizenship> citizenships { get; set; }

        public Client(DBClient option)
        {
            this.id = option.id;
            this.first_name = option.first_name;
            this.second_name = option.second_name;
            this.midle_name = option.midle_name;
            this.birthday = option.birthday;
            this.sex = option.sex;
            this.passport_series = option.passport_series;
            this.passport_number = option.passport_number;
            this.authority = option.authority;
            this.date_of_issue = option.date_of_issue;
            this.place_of_birth = option.place_of_birth;
            this.mobile_phone = option.mobile_phone;
            this.home_phone = option.home_phone;
            this.e_mail = option.e_mail;
            this.work_place = option.work_place;
            this.work_position = option.work_position;
            this.address_of_registration = option.address_of_registration;
            this.retired = option.retired;
            this.monthly_income = option.monthly_income;
            this.military_conscription = option.military_conscription;
        }

    }

    [Table("m2m_client_family")]
    public class m2m_client_family
    {
        [Key]
        public string id { get; set; }

        [Key]
        public int id_family_status { get; set; }

    }

    [Table("m2m_client_citezenship")]
    public class m2m_client_citezenship
    {
        [Key]
        public string id { get; set; }
        [Key]
        public int citizenship_id { get; set; }
    }

    [Table("m2m_client_Disabilities")]
    public class m2m_client_Disabilities
    {
        [Key]
        public string id { get; set; }

        [Key]
        public int dis_id { get; set; }
    }

    [Table("m2m_client_live")]
    public class m2m_client_live
    {
        [Key]
        public string id { get; set; }
        [Key]
        public int city_id { get; set; }
    }

    [Table("m2m_client_residence")]
    public class m2m_client_residence
    {
        [Key]
        [Column("client_id")]
        public string id { get; set; }
        [Key]
        public int city_id { get; set;} 
    }
}
