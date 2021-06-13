using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TelegramBotService
{
    public class TotalValues
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
    }

    public class Delta
    {
        public int confirmed { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
    }

    public class Ahmednagar
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Akola
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Amravati
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Aurangabad
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Beed
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Bhandara
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Buldhana
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Chandrapur
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Dhule
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Gadchiroli
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Gondia
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Hingoli
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Jalgaon
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Jalna
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Kolhapur
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Latur
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Mumbai
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class MumbaiSuburban
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Nagpur
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Nanded
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Nandurbar
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Nashik
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Osmanabad
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class OtherState
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Palghar
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Parbhani
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Pune
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Raigad
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Ratnagiri
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Sangli
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Satara
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Sindhudurg
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Solapur
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Thane
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Agra
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Wardha
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Washim
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Yavatmal
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class District
    {
        public Ahmednagar Ahmednagar { get; set; }
        public Akola Akola { get; set; }
        public Amravati Amravati { get; set; }
        public Aurangabad Aurangabad { get; set; }
        public Beed Beed { get; set; }
        public Bhandara Bhandara { get; set; }
        public Buldhana Buldhana { get; set; }
        public Chandrapur Chandrapur { get; set; }
        public Dhule Dhule { get; set; }
        public Gadchiroli Gadchiroli { get; set; }
        public Gondia Gondia { get; set; }
        public Hingoli Hingoli { get; set; }
        public Jalgaon Jalgaon { get; set; }
        public Jalna Jalna { get; set; }
        public Kolhapur Kolhapur { get; set; }
        public Latur Latur { get; set; }
        public Mumbai Mumbai { get; set; }
        public MumbaiSuburban MumbaiSuburban { get; set; }
        public Nagpur Nagpur { get; set; }
        public Nanded Nanded { get; set; }
        public Nandurbar Nandurbar { get; set; }
        public Nashik Nashik { get; set; }
        public Osmanabad Osmanabad { get; set; }
        public OtherState OtherState { get; set; }
        public Palghar Palghar { get; set; }
        public Parbhani Parbhani { get; set; }
        public Pune Pune { get; set; }
        public Raigad Raigad { get; set; }
        public Ratnagiri Ratnagiri { get; set; }
        public Sangli Sangli { get; set; }
        public Satara Satara { get; set; }
        public Sindhudurg Sindhudurg { get; set; }
        public Solapur Solapur { get; set; }
        public Thane Thane { get; set; }
        public Wardha Wardha { get; set; }
        public Washim Washim { get; set; }
        public Yavatmal Yavatmal { get; set; }
        public Agra Agra { get; set; }
        public Aligarh Aligarh { get; set; }
        [JsonProperty(PropertyName = "Ambedkar Nagar")]
        public AmbedkarNagar AmbedkarNagar { get; set; }
        public Amethi Amethi { get; set; }
        public Amroha Amroha { get; set; }
        public Auraiya Auraiya { get; set; }
        public Ayodhya Ayodhya { get; set; }
        public Azamgarh Azamgarh { get; set; }
        public Baghpat Baghpat { get; set; }
        public Bahraich Bahraich { get; set; }
        public Ballia Ballia { get; set; }
        public Balrampur Balrampur { get; set; }
        public Banda Banda { get; set; }
        public Barabanki Barabanki { get; set; }
        public Bareilly Bareilly { get; set; }
        public Basti Basti { get; set; }
        public Ghaziabad Ghaziabad { get; set; }

    }

    public class Ghaziabad
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Basti
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Bareilly
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Barabanki
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Banda
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Ballia
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Balrampur
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Bahraich
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Baghpat
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Azamgarh
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Ayodhya
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Auraiya
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Amroha
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Amethi
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class AmbedkarNagar
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Aligarh
    {
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int migratedother { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }

    public class Maharashtra
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Karnataka
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Kerala
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class TamilNadu
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class AndhraPradesh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class UttarPradesh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Delhi
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class WestBengal
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Chhattisgarh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Rajasthan
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Gujarat
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Odisha
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class MadhyaPradesh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Haryana
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Bihar
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Telangana
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Punjab
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Assam
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Jharkhand
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Uttarakhand
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class JammuAndKashmir
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class HimachalPradesh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Goa
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Puducherry
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Chandigarh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Tripura
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Manipur
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Meghalaya
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class ArunachalPradesh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Nagaland
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Ladakh
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Sikkim
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Mizoram
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class DadraAndNagarHaveliAndDamanAndDiu
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class Lakshadweep
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class AndamanAndNicobarIslands
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class StateUnassigned
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string deltaconfirmed { get; set; }
        public string deltadeaths { get; set; }
        public string deltarecovered { get; set; }
        public string lastupdatedtime { get; set; }
        public string migratedother { get; set; }
        public string recovered { get; set; }
        public string state { get; set; }
        public string statecode { get; set; }
        public string statenotes { get; set; }
        public District district { get; set; }
    }

    public class StateWise
    {
        public Maharashtra Maharashtra { get; set; }
        public Karnataka Karnataka { get; set; }
        public Kerala Kerala { get; set; }
        [JsonProperty(PropertyName = "Tamil Nadu")]
        public TamilNadu TamilNadu { get; set; }
        [JsonProperty(PropertyName = "Andhra Pradesh")]
        public AndhraPradesh AndhraPradesh { get; set; }
        [JsonProperty(PropertyName = "Uttar Pradesh")]
        public UttarPradesh UttarPradesh { get; set; }
        public Delhi Delhi { get; set; }
        [JsonProperty(PropertyName = "West Bengal")]
        public WestBengal WestBengal { get; set; }
        public Chhattisgarh Chhattisgarh { get; set; }
        public Rajasthan Rajasthan { get; set; }
        public Gujarat Gujarat { get; set; }
        public Odisha Odisha { get; set; }
        [JsonProperty(PropertyName = "Madhya Pradesh")]
        public MadhyaPradesh MadhyaPradesh { get; set; }
        public Haryana Haryana { get; set; }
        public Bihar Bihar { get; set; }
        public Telangana Telangana { get; set; }
        public Punjab Punjab { get; set; }
        public Assam Assam { get; set; }
        public Jharkhand Jharkhand { get; set; }
        public Uttarakhand Uttarakhand { get; set; }
        [JsonProperty(PropertyName = "Jammu and Kashmir")]
        public JammuAndKashmir JammuandKashmir { get; set; }
        [JsonProperty(PropertyName = "Himachal Pradesh")]
        public HimachalPradesh HimachalPradesh { get; set; }
        public Goa Goa { get; set; }
        public Puducherry Puducherry { get; set; }
        public Chandigarh Chandigarh { get; set; }
        public Tripura Tripura { get; set; }
        public Manipur Manipur { get; set; }
        public Meghalaya Meghalaya { get; set; }
        [JsonProperty(PropertyName = "Arunachal Pradesh")]
        public ArunachalPradesh ArunachalPradesh { get; set; }
        public Nagaland Nagaland { get; set; }
        public Ladakh Ladakh { get; set; }
        public Sikkim Sikkim { get; set; }
        public Mizoram Mizoram { get; set; }
        [JsonProperty(PropertyName = "Dadra and Nagar Haveli and Daman and Diu")]
        public DadraAndNagarHaveliAndDamanAndDiu DadraandNagarHaveliandDamanandDiu { get; set; }
        public Lakshadweep Lakshadweep { get; set; }
        [JsonProperty(PropertyName = "Andaman and Nicobar Islands")]
        public AndamanAndNicobarIslands AndamanandNicobarIslands { get; set; }
        [JsonProperty(PropertyName = "State Unassigned")]
        public StateUnassigned StateUnassigned { get; set; }
    }

    public class CovidInfoModel
    {
        [JsonProperty(PropertyName = "key_values")]
        public object key_values { get; set; }
        [JsonProperty(PropertyName = "total_values")]
        public TotalValues total_values { get; set; }
        [JsonProperty(PropertyName = "state_wise")]
        public StateWise state_wise { get; set; }
    }
}
