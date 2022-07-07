﻿namespace Rabobank.Training.ClassLibrary.ViewModels
{
    /// <summary>
    /// This View Model class to be used by and client side to display position information along with list of mapped MandateVM objects.
    /// </summary>
    public class PositionVM
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public List<MandateVM>? Mandates { get; set; }
    }
}
