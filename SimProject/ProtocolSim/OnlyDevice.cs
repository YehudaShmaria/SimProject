//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProtocolSim
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class OnlyDevice
    {
        public int SId { get; set; }
        [DisplayName("�� ������")]
        public string DeviceName { get; set; }
        [Required]
        [DisplayName("IMEI �����")]
        public string ImeiDevice { get; set; }
    }
}