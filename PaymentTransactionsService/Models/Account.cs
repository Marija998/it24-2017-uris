﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionServiceAPI.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }

        [Precision(18, 2)]
        public decimal Balance { get; set; }

        [Required]
        [AllowedValues("AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "ATS", "AUD", "AWG", "AZN", "BAM", "BBD", "BDT", "BEF", "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BRL", "BSD", "BTC", "BTN", "BWP", "BYN", "BYR", "BZD", "CAD", "CDF", "CHF", "CLF", "CLP", "CNH", "CNY", "COP", "CPI", "CRC", "CUC", "CUP", "CVE", "CYP", "CZK", "DEM", "DJF", "DKK", "DOP", "DZD", "EEK", "EGP", "ERN", "ESP", "ETB", "EUR", "FIM", "FJD", "FKP", "FRF", "GBP", "GEL", "GGP", "GHS", "GIP", "GMD", "GNF", "GRD", "GTQ", "GYD", "HKD", "HNL", "HRK", "HTG", "HUF", "IDR", "IEP", "ILS", "IMP", "INR", "IQD", "IRR", "ISK", "ITL", "JEP", "JMD", "JOD", "JPY", "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", "LTL", "LUF", "LVL", "LYD", "MAD", "MCF", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MRU", "MTL", "MUR", "MVR", "MWK", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NLG", "NOK", "NPR", "NZD", "OMR", "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PTE", "PYG", "QAR", "RON", "RSD", "RUB", "RWF", "SAR", "SBD", "SCR", "SDG", "SEK", "SGD", "SHP", "SIT", "SKK", "SLL", "SML", "SOS", "SRD", "SSP", "STD", "STN", "SVC", "SYP", "SZL", "THB", "TJS", "TMT", "TND", "TOP", "TRY", "TTD", "TWD", "TZS", "UAH", "UGX", "USD", "UYU", "UZS", "VAL", "VEB", "VEF", "VES", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XCD", "XCP", "XDR", "XOF", "XPD", "XPF", "XPT", "YER", "ZAR", "ZMK", "ZMW", "ZWL")]
        public string Currency { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
