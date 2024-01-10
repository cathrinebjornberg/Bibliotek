public class Media
{
    protected static int nextId = 1;

    public bool Available { get; set; } = true;


    public void Borrow()
    {
        Available = false;
        // Till vem?
    }
}