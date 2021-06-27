
using System.Collections.Generic;
using Team_Project_Paint.Class;

namespace Team_Project_Paint.Interfaces
{
    public interface IJsonLogic
    {

        List<AbstractShape> JsonList { get; set; }
        string File { get; set; }

        void JsonDeserialize(string jsonfile);

        //void JsonSerialize(List<IShape> shapeList);
    }
}
