using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class Roster
    {
        public int Id {  get; set; }
        
        
        public DateOnly Date { get; set; }

        /*
        private bool time0_1;
        private bool time1_2;
        private bool time2_3;
        private bool time3_4;
        private bool time4_5;
        private bool time5_6;
        private bool time6_7;
        private bool time7_8;
        private bool time8_9;
        private bool time9_10;
        private bool time10_11;
        private bool time11_12;
        private bool time12_13;
        private bool time13_14;
        private bool time14_15;
        private bool time15_16;
        private bool time16_17;
        private bool time17_18;
        private bool time18_19;
        private bool time19_20;
        private bool time20_21;
        private bool time21_22;
        private bool time22_23;
        private bool time23_0;
        */
        private int StaffId { get; set; }

    }
}
