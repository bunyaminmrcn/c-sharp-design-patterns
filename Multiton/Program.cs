namespace Multiton;

class Program
{
    static void Main(string[] args)
    {
        Camera camera1 = Camera.GetCamera("NIKON");
        Camera camera2 = Camera.GetCamera("NIKON");
        Camera camera3 = Camera.GetCamera("CANON");
        Camera camera4 = Camera.GetCamera("CANON");

        Console.WriteLine(camera1.id);
        Console.WriteLine(camera2.id);
        Console.WriteLine(camera3.id);
        Console.WriteLine(camera4.id);
    }
}


class Camera {
    public Guid id { get;set;}
    static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
    static object _lock = new object();
    
    private Camera() {
        id = Guid.NewGuid();
    }
    public static Camera GetCamera(string brand) {
        lock (_lock) {
            if(!_cameras.ContainsKey(brand)) {
                _cameras.Add(brand, new Camera());
            }
        }
        return _cameras[brand];
    }
}