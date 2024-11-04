using System.ComponentModel.DataAnnotations;

namespace AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate.Enums;

public enum PregnancyOutcome
{
    [Display(Name = "Ongoing Pregnancy")]
    OngoingPregnancy = 0,

    [Display(Name = "Live Birth")]
    LiveBirth = 1,

    [Display(Name = "Preterm Birth")]
    PretermBirth = 2,

    [Display(Name = "Still Birth")]
    StillBirth = 3,

    [Display(Name = "Abortion")]
    Abortion = 4,
}
