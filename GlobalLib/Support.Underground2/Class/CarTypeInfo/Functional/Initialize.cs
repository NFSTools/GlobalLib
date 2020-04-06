using GlobalLib.Support.Underground2.Parts.CarParts;
using GlobalLib.Support.Underground2.Parts.InfoParts;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private void Initialize()
        {
            this.ECAR = new Ecar();
            this.PVEHICLE = new Pvehicle();
            this.AI_CAMERA_DRIVER = new Camera();
            this.AI_CAMERA_CLOSE = new Camera();
            this.AI_CAMERA_DRIFT = new Camera();
            this.AI_CAMERA_BUMPER = new Camera();
            this.AI_CAMERA_FAR = new Camera();
            this.AI_CAMERA_HOOD = new Camera();
            this.PLAYER_CAMERA_DRIVER = new Camera();
            this.PLAYER_CAMERA_CLOSE = new Camera();
            this.PLAYER_CAMERA_DRIFT = new Camera();
            this.PLAYER_CAMERA_BUMPER = new Camera();
            this.PLAYER_CAMERA_FAR = new Camera();
            this.PLAYER_CAMERA_HOOD = new Camera();
            this.BASE_BRAKES = new Brakes();
            this.BASE_ENGINE = new Engine();
            this.BASE_RPM = new RPM();
            this.BASE_SUSPENSION = new Suspension();
            this.BASE_TIRES = new Tires();
            this.BASE_TRANSMISSION = new Transmission();
            this.BASE_TURBO = new Turbo();
            this.DRIFT_ADD_CONTROL = new DriftControl();
            this.STREET_ECU = new ECU();
            this.STREET_RPM = new RPM();
            this.STREET_TRANSMISSION = new Transmission();
            this.PRO_ECU = new ECU();
            this.PRO_RPM = new RPM();
            this.PRO_TRANSMISSION = new Transmission();
            this.TOP_BRAKES = new Brakes();
            this.TOP_ECU = new ECU();
            this.TOP_ENGINE = new Engine();
            this.TOP_NITROUS = new Nitrous();
            this.TOP_RPM = new RPM();
            this.TOP_SUSPENSION = new Suspension();
            this.TOP_TIRES = new Tires();
            this.TOP_TRANSMISSION = new Transmission();
            this.TOP_TURBO = new Turbo();
            this.TOP_WEIGHT_REDUCTION = new WeightReduction();
            this.WHEEL_FRONT_LEFT = new CarInfoWheel();
            this.WHEEL_FRONT_RIGHT = new CarInfoWheel();
            this.WHEEL_REAR_LEFT = new CarInfoWheel();
            this.WHEEL_REAR_RIGHT = new CarInfoWheel();
            this.CARSKIN01 = new CarSkin();
            this.CARSKIN02 = new CarSkin();
            this.CARSKIN03 = new CarSkin();
            this.CARSKIN04 = new CarSkin();
            this.CARSKIN05 = new CarSkin();
            this.CARSKIN06 = new CarSkin();
            this.CARSKIN07 = new CarSkin();
            this.CARSKIN08 = new CarSkin();
            this.CARSKIN09 = new CarSkin();
            this.CARSKIN10 = new CarSkin();
        }
    }
}