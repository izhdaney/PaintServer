using System.Collections.Generic;
using Team_Project_Paint.Class.OperationWithFigures;
using Team_Project_Paint.PaintEnum;
using Team_Project_Paint.Interfaces;
using Team_Project_Paint.Class.FigureDrawingClass;

namespace Team_Project_Paint.Class
{
    public class AbstractShape : IShape
    {
        private EShapeType name;
        private EShapeStatus _eHsapeStatus = EShapeStatus.NOT_STARTED;

        public AbstractShape(EShapeType name)
        {
            this.name = name;
        }
        public int Thickness { get; set;}
        public EShapeType Name
        {
            get => name;
        }

        public int Numb { get; set; }
        public bool IsSelected { get; set; }
        public ShapePoint FinishLocation { get; set; }
        public ShapePoint Location { get; set; }
        public PaintColor Color { get; set; }
        public ShapeSize Size { get; set; }

        public EShapeStatus EShapeStatus
        {
            get { return _eHsapeStatus; }
            set { _eHsapeStatus = value; }
        }

        
    }
}
