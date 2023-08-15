using siades.Default;

namespace siades.Models;
[Serializable]
public class Blood : EntityDefault
{
    public string BloodGroupName { get; set; }
    public List<BloodRequest> ListRequest { get; set; }
    public List<Person> People { get; set; }

}