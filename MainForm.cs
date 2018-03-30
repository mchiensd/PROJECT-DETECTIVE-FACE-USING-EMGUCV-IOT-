

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Text;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Khai báo toàn bộ biến cục bộ 
        bool eyesfocus = false;
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null, TrainedEyes = null,resultEyes;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<Image<Gray, byte>> trainingImagesEyes = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> labelsEyes = new List<string>();
        List<string> NamePersons = new List<string>();
        List<string> NamePersonsEyes = new List<string>();
        //cai nao co nameprson trong th eyes thy bo
        int ContTrain, NumLabels, t,tEyes,NumLabelsEyes,ContTrainEyes;
        string name, names = null,nameEyes,namesEyes;
        int trainningnumber = 0;
        int bri = 0;
        public FrmPrincipal()
        {
            InitializeComponent();
//            if(!File.Exists("TrainedFaces"))
//            {
//                System.IO.Directory.CreateDirectory("./TrainedFaces");
//            }
//            if (!File.Exists("TrainedEyes"))
//            {
//                System.IO.Directory.CreateDirectory("./TrainedEyes");
//            }
//            //Load dữ liệu mắt và mặt (file xml) có sẵn trên forum EMGUCV
//            face = new HaarCascade("haarcascade_frontalface_default.xml");
//            eye = new HaarCascade("haarcascade_eye_tree_eyeglasses.xml");
//            try
//            {
//                //Load Các dữ liệu huấn luyện đã có
//                string Labelsinfo = File.ReadAllText("./TrainedFaces/TrainedLabels.txt");
//                string[] Labels = Labelsinfo.Split('%');
//                NumLabels = Convert.ToInt16(Labels[0]);
//                ContTrain = NumLabels;
//                string LoadFaces;

//                for (int tf = 1; tf < NumLabels + 1; tf++)
//                {
//                    LoadFaces = "face" + tf + ".bmp";
//                    trainingImages.Add(new Image<Gray, byte>("./TrainedFaces/" + LoadFaces));
//                    labels.Add(Labels[tf]);
//                }
////-------------Eyes-------------
//                string LabelsinfoEyes = File.ReadAllText("./TrainedEyes/TrainedLabels.txt");
//                string[] LabelsEyes = Labelsinfo.Split('%');
//                NumLabelsEyes = Convert.ToInt16(LabelsEyes[0]);
//                ContTrainEyes = NumLabelsEyes;
//                string LoadFacesEyes;

//                for (int tf = 1; tf < NumLabelsEyes + 1; tf++)
//                {
//                    LoadFacesEyes = "eyes" + tf + ".bmp";
//                    trainingImagesEyes.Add(new Image<Gray, byte>("./TrainedEyes/" + LoadFacesEyes));
//                    labelsEyes.Add(LabelsEyes[tf]);
//                }

//            }
//            catch (Exception e)
//            {
//                //MessageBox.Show(e.ToString());
//                MessageBox.Show("Không có dữ liệu tranning", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }

           

        }
        public static void Empty()
            {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("./TrainedFaces");
            try
            {
                foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                System.IO.DirectoryInfo directoryEyes = new System.IO.DirectoryInfo("./TrainedEyes");
                foreach (System.IO.FileInfo file in directoryEyes.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directoryEyes.GetDirectories()) subDirectory.Delete(true);
            }
            catch(Exception ex)
            {

            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            
            Empty();
            MessageBox.Show("Đã xóa tất cả dữ liệu tranning", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmPrincipal fr = new FrmPrincipal();
            this.Hide();
            fr.Show();
           
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void mởTậpTinẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipal_Load(sender, e);
            label4.Text = "";
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Images|*.jpg|PNG Images|*.png|All Files |*.*";
            openFileDialog1.Title = "Chọn file ảnh";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imageBoxFrameGrabber.Image = new Image<Bgr, Byte>(openFileDialog1.FileName);
                currentFrame = new Image<Bgr, Byte>(openFileDialog1.FileName);
                gray = new Image<Gray, Byte>(new Bitmap(openFileDialog1.FileName));
                FrameGrabberimg();
            }
          
        }

        private void FrameGrabberimg()
        {
            NamePersons.Add("Khong x.dinh");
            NamePersonsEyes.Add("Khong x.dinh");
            MCvAvgComp[][] facesDetected;
            //Face Detector
            if (checkBox1.Checked)
            {
                facesDetected = gray.DetectHaarCascade(
         face,
         1.1,
         10,
         Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
         new Size(20, 20));
            }
            else
            {
                facesDetected = gray.DetectHaarCascade(
          face,
          1.1,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT,
          new Size(20, 20));
            }

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {

                imageBox3.Image = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Int32 yCoordStartSearchEyes = f.rect.Top + (f.rect.Height * 3 / 11);
                Point startingPointSearchEyes = new Point(f.rect.X, yCoordStartSearchEyes);
                Size searchEyesAreaSize = new Size(f.rect.Width, (f.rect.Height * 3 / 11));
                Rectangle possibleROI_eyes = new Rectangle(startingPointSearchEyes, searchEyesAreaSize);
                t = t + 1;
                tEyes = tEyes+1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                resultEyes = currentFrame.Copy(possibleROI_eyes).Convert<Gray, byte>().Resize(100, 30, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Yellow), 1);
                currentFrame.Draw(new CircleF(new PointF(f.rect.X, f.rect.Y), 1), new Bgr(Color.Yellow), 10);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X, f.rect.Y), new Point(f.rect.X - 80, f.rect.Y)), new Bgr(Color.Yellow), 2);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X - 80, f.rect.Y), new Point(f.rect.X - 80, f.rect.Y - 30)), new Bgr(Color.Yellow), 1);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X - 80, f.rect.Y - 30), new Point(f.rect.X - 150, f.rect.Y - 30)), new Bgr(Color.Yellow), 1);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X - 80, f.rect.Y - 30), new Point(f.rect.X - 70, f.rect.Y - 30)), new Bgr(Color.Yellow), 1);

                currentFrame.Draw(possibleROI_eyes, new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new CircleF(new PointF(possibleROI_eyes.X, possibleROI_eyes.Y + possibleROI_eyes.Height), 1), new Bgr(Color.DeepPink), 5);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X, possibleROI_eyes.Y + possibleROI_eyes.Height), new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height), new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height + 120)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height + 120), new Point(possibleROI_eyes.X, possibleROI_eyes.Y + possibleROI_eyes.Height + 120)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height + 120), new Point(possibleROI_eyes.X - 80, possibleROI_eyes.Y + possibleROI_eyes.Height + 120)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw("Eyes Area", ref font, new Point(possibleROI_eyes.X - 80, possibleROI_eyes.Y + possibleROI_eyes.Height + 130), new Bgr(Color.DeepPink));
                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    if (trainingImagesEyes.ToArray().Length != 0)
                    {

                        MCvTermCriteria termCritEyes = new MCvTermCriteria(ContTrainEyes, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizerEyes = new EigenObjectRecognizer(
                           trainingImagesEyes.ToArray(),
                           labelsEyes.ToArray(),
                           3000,
                           ref termCritEyes);
                        nameEyes = recognizerEyes.Recognize(resultEyes);
                        if (name == nameEyes)
                        {
                            currentFrame.Draw(nameEyes, ref font, new Point(f.rect.X - 150, f.rect.Y - 35), new Bgr(Color.Red));
                        }
                        else
                        {
                            currentFrame.Draw("noname", ref font, new Point(f.rect.X - 150, f.rect.Y - 35), new Bgr(Color.Red));
                        }

                    }

                }
                else
                {

                    currentFrame.Draw("noname", ref font, new Point(f.rect.X - 150, f.rect.Y - 35), new Bgr(Color.Red));
                }

               NamePersons[t - 1] = name;
               NamePersonsEyes[tEyes - 1] = nameEyes;
                NamePersons.Add("");
                NamePersonsEyes.Add("");


                //Set the number of faces detected on the scene
                label3.Text = facesDetected[0].Length.ToString();


                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);


                    //var Arrayeyes = eyesDetected[0];
                    // Arrayeyes[0].rect.X
                    if (eyesfocus)
                    {
                        currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 1);
                        if (eyeRect.X < f.rect.X + (f.rect.Width / 2))
                        {
                            currentFrame.Draw(new CircleF(new PointF(eyeRect.X, eyeRect.Y), 1), new Bgr(Color.Blue), 5);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X, eyeRect.Y), new Point(eyeRect.X - 100, eyeRect.Y)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X - 100, eyeRect.Y), new Point(eyeRect.X - 100, eyeRect.Y + 15)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X - 100, eyeRect.Y + 15), new Point(eyeRect.X - 170, eyeRect.Y + 15)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw("right eye", ref font, new Point(eyeRect.X - 185, eyeRect.Y + 10), new Bgr(Color.Blue));
                        }

                        else
                        {
                            currentFrame.Draw(new CircleF(new PointF(eyeRect.X + eyeRect.Width, eyeRect.Y), 1), new Bgr(Color.Blue), 5);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width, eyeRect.Y), new Point(eyeRect.X + eyeRect.Width, eyeRect.Y - 100)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width, eyeRect.Y - 100), new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 100)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 100), new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 90)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 90), new Point(eyeRect.X + eyeRect.Width + 140, eyeRect.Y - 90)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw("left eye", ref font, new Point(eyeRect.X + eyeRect.Width + 45, eyeRect.Y - 95), new Bgr(Color.Blue));
                        }
                    }


                }


            }
            t = 0;
            tEyes = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
                namesEyes = namesEyes + NamePersonsEyes[nnn] + ", ";

            }


            //Show the faces procesed and recognized
            //  imageBoxFrameGrabber.Image = currentFrame.Flip(FLIP.HORIZONTAL);
            if (camlive)
                imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            nameEyes = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
            NamePersonsEyes.Clear();
        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // Application.StartupPath + @"/Backup/Eyes" + xxx + ".zipe" + "%" + Application.StartupPath + @"/Backup/Faces" + xxx + ".zipf"
            string xxx = DateTime.Now.ToString().Trim().Replace(':', '_').Replace('/', '_').Trim();
            try
            {
                System.IO.Directory.CreateDirectory("./Backup");
                ZipFile.CreateFromDirectory("TrainedFaces", Application.StartupPath + @"/Backup/Faces" + xxx + ".zipf");
                ZipFile.CreateFromDirectory("TrainedEyes", Application.StartupPath +@"/Backup/Eyes" + xxx + ".zipe");
                if (File.Exists("./Backupdata.txt"))//kiểm tra nếu chưa có file
                {
                    using (StreamWriter sw = File.AppendText("./Backupdata.txt"))
                    {
                        sw.Write("%" + "./Backup/Eyes" + xxx + ".zipe" + "%" + "./Backup/Faces" + xxx + ".zipf");
                    }
                }
                else
                {
                    if (!File.Exists("./Backupdata.txt"))//kiểm tra nếu chưa có file
                    {
                        using (StreamWriter sw = File.AppendText("./Backupdata.txt"))
                        {
                            sw.Write("%"+"./Backup/Eyes" + xxx + ".zipe" + "%" + "./Backup/Faces" + xxx + ".zipf");
                        }
                    }
                }
                

            
                MessageBox.Show("Đã sao lưu :"+ xxx + " vào thư mục D");
            }
            catch(Exception ex)
            {
               MessageBox.Show("Lỗi sao lưu" + ex.ToString());
            }
        }

        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void mENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void phụcHồiDữLiệuToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();
            FileStream file = new FileStream("./Backupdata.txt", FileMode.Open);
            StreamReader read = new StreamReader(file);
            var arr = read.ReadToEnd().ToString().Split('%');
            read.Close();
            for(int i = 0; i < arr.Length; i=i+2)
            {
                toolStripComboBox1.Items.Add(arr[i]);
            }
            
        }

        private void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            Empty();
            DialogResult dialogResult = MessageBox.Show("Phục hồi dữ liệu - Sẻ mất dữ liệu cũ", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string pathfilesfaces = toolStripComboBox1.Text;
                    string pathfileseyes = toolStripComboBox1.Text.Remove(9, 4).Insert(9, "Eye").Remove(toolStripComboBox1.Text.Remove(9, 4).Insert(9, "Eye").Length-1,1)+"e";
                    ZipFile.ExtractToDirectory(pathfileseyes, "./TrainedEyes");
                    ZipFile.ExtractToDirectory(pathfilesfaces, "./TrainedFaces");
                    MessageBox.Show("Đã hoàn tất phục hồi");
                    FrmPrincipal_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
           
        }

        private void thôngTinVềTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tĐồ án chuyên ngành\nĐề Tài:\tỨng dụng nhận diện khuôn mặt bằng EmguCV\nHọ tên SV:\tTrần Minh Chiến\nMSSV:\t\t1411060028\nLớp:\t\t14DTHC01","Giới thiệu",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void xóaDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           


            DialogResult dialogResult = MessageBox.Show("Phục hồi dữ liệu - Sẻ mất dữ liệu cũ", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Empty();
                    MessageBox.Show("Đã xóa tất cả dữ liệu tranning", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmPrincipal fr = new FrmPrincipal();
                    this.Hide();
                    fr.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void quảnLíDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager a = new Manager();
            a.Show();
        }

     
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (!File.Exists("TrainedFaces"))
            {
                System.IO.Directory.CreateDirectory("./TrainedFaces");
            }
            if (!File.Exists("TrainedEyes"))
            {
                System.IO.Directory.CreateDirectory("./TrainedEyes");
            }
            //Load dữ liệu mắt và mặt (file xml) có sẵn trên forum EMGUCV
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            eye = new HaarCascade("haarcascade_eye_tree_eyeglasses.xml");
            try
            {
                //Load Các dữ liệu huấn luyện đã có
                string Labelsinfo = File.ReadAllText("./TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>("./TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
                //-------------Eyes-------------
                string LabelsinfoEyes = File.ReadAllText("./TrainedEyes/TrainedLabels.txt");
                string[] LabelsEyes = Labelsinfo.Split('%');
                NumLabelsEyes = Convert.ToInt16(LabelsEyes[0]);
                ContTrainEyes = NumLabelsEyes;
                string LoadFacesEyes;

                for (int tf = 1; tf < NumLabelsEyes + 1; tf++)
                {
                    LoadFacesEyes = "eyes" + tf + ".bmp";
                    trainingImagesEyes.Add(new Image<Gray, byte>("./TrainedEyes/" + LoadFacesEyes));
                    labelsEyes.Add(LabelsEyes[tf]);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Không có dữ liệu tranning", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (trainningnumber < int.Parse(textBox2.Text)) { 
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;
                    ContTrainEyes = ContTrainEyes + 1;

                    //Get a gray frame from capture device
                    if(camlive)
                    gray = grabber.QueryGrayFrame().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    else
                    {

                    }

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.1,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
               
                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                        Int32 yCoordStartSearchEyes = f.rect.Top + (f.rect.Height * 3 / 11);
                        Point startingPointSearchEyes = new Point(f.rect.X, yCoordStartSearchEyes);
                        Size searchEyesAreaSize = new Size(f.rect.Width, (f.rect.Height * 3 / 11));
                        Rectangle possibleROI_eyes = new Rectangle(startingPointSearchEyes, searchEyesAreaSize);
                        TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                        TrainedEyes = currentFrame.Copy(possibleROI_eyes).Convert<Gray, byte>();
                    break;
                }

                //test image with cubic interpolation type method & resize face detected image for force to compare the same size with the 
                TrainedFace = result.Resize(100,100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    TrainedEyes = resultEyes.Resize(100, 30, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    trainingImagesEyes.Add(TrainedEyes);
                    trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);
                    labelsEyes.Add(textBox1.Text);


                    //Show face added in gray scale
                    imageBox1.Image = TrainedFace;
                    imageBox2.Image = TrainedEyes;

                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText("./TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");
                    File.WriteAllText("./TrainedEyes/TrainedLabels.txt", trainingImagesEyes.ToArray().Length.ToString() + "%");

                    //Write the labels of triained faces in a file text for further load
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save("./TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText("./TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }
                    for (int i = 1; i < trainingImagesEyes.ToArray().Length + 1; i++)
                    {
                        trainingImagesEyes.ToArray()[i - 1].Save("./TrainedEyes/eyes" + i + ".bmp");
                        File.AppendAllText("./TrainedEyes/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }

                    textBox2.Text = (int.Parse(textBox2.Text) - 1).ToString();
                    trainningnumber++;
                }
            catch
            {
                MessageBox.Show("Xác thực mặt trước", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
               
            }
            else
            {
                MessageBox.Show(textBox1.Text + " - Đã tranning xong:)", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Enabled = false;
              
              
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label11.Text = trackBar1.Value.ToString();
            bri = trackBar1.Value;
        }
        bool flagcam = false,camlive = false,clickedstart=true;
        private void button1_Click(object sender, EventArgs e)
        {
          

            if (flagcam)
            {
                
                button1.Text = "Bật Camera & nhận diện";
                flagcam = false;
                camlive = false;
            }
            else
            {
                if (clickedstart)
                {
                    grabber = new Capture(0);
                }
                button1.Text = "Dừng";
                grabber.QueryFrame();   
                Application.Idle += new EventHandler(FrameGrabber);
                flagcam = true;
                camlive = true;
                clickedstart = false;
            }
           
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            trainningnumber = 0;
            timer1.Enabled = true;
       
        }


        public void FrameGrabber(object sender, EventArgs e)
        {
           
            if (checkBox2.Checked)
            {
                eyesfocus = true;
            }
            else
            {
                eyesfocus = false;
            }
            label3.Text = "0";
            label4.Text = "";
          
                NamePersons.Add("Khong x.dinh");
                NamePersonsEyes.Add("Khong x.dinh");
           
       


            //Get the current frame form capture device
            //currentFrame = grabber.QueryFrame().Resize(550, 450, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
          
         currentFrame = grabber.QueryFrame().Resize(600, 400, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            if (label11.Text != "00" || label11.Text != "1" || label11.Text != "-1")
            {
                currentFrame = new Image<Bgr, Byte>(AdjustBrightness(currentFrame.ToBitmap(), bri));
            }

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected;
            //Face Detector
            if (checkBox1.Checked)
            {
                facesDetected = gray.DetectHaarCascade(
         face,
         1.1,
         10,
         Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
         new Size(20, 20));
            }
            else
            {
                facesDetected = gray.DetectHaarCascade(
          face,
          1.1,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT,
          new Size(20, 20));
            }

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {

                imageBox3.Image = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Int32 yCoordStartSearchEyes = f.rect.Top + (f.rect.Height * 3 / 11);
                Point startingPointSearchEyes = new Point(f.rect.X, yCoordStartSearchEyes);
                Size searchEyesAreaSize = new Size(f.rect.Width, (f.rect.Height * 3 / 11));
                Rectangle possibleROI_eyes = new Rectangle(startingPointSearchEyes, searchEyesAreaSize);
                t = t + 1;
                tEyes++;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                resultEyes = currentFrame.Copy(possibleROI_eyes).Convert<Gray, byte>().Resize(100, 30, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Yellow), 1);
                currentFrame.Draw(new CircleF(new PointF(f.rect.X, f.rect.Y), 1), new Bgr(Color.Yellow), 10);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X, f.rect.Y), new Point(f.rect.X - 80, f.rect.Y)), new Bgr(Color.Yellow), 2);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X - 80, f.rect.Y), new Point(f.rect.X - 80, f.rect.Y - 30)), new Bgr(Color.Yellow), 1);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X - 80, f.rect.Y - 30), new Point(f.rect.X - 150, f.rect.Y - 30)), new Bgr(Color.Yellow), 1);
                currentFrame.Draw(new LineSegment2D(new Point(f.rect.X - 80, f.rect.Y - 30), new Point(f.rect.X - 70, f.rect.Y - 30)), new Bgr(Color.Yellow), 1);

                currentFrame.Draw(possibleROI_eyes, new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new CircleF(new PointF(possibleROI_eyes.X, possibleROI_eyes.Y + possibleROI_eyes.Height), 1), new Bgr(Color.DeepPink), 5);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X, possibleROI_eyes.Y + possibleROI_eyes.Height), new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height), new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height + 120)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height + 120), new Point(possibleROI_eyes.X, possibleROI_eyes.Y + possibleROI_eyes.Height + 120)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw(new LineSegment2D(new Point(possibleROI_eyes.X - 40, possibleROI_eyes.Y + possibleROI_eyes.Height + 120), new Point(possibleROI_eyes.X - 80, possibleROI_eyes.Y + possibleROI_eyes.Height + 120)), new Bgr(Color.DeepPink), 1);
                currentFrame.Draw("Eyes Area", ref font, new Point(possibleROI_eyes.X - 80, possibleROI_eyes.Y + possibleROI_eyes.Height + 130), new Bgr(Color.DeepPink));
                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    if (trainingImagesEyes.ToArray().Length != 0)
                    {

                        MCvTermCriteria termCritEyes = new MCvTermCriteria(ContTrainEyes, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizerEyes = new EigenObjectRecognizer(
                           trainingImagesEyes.ToArray(),
                           labelsEyes.ToArray(),
                           3000,
                           ref termCritEyes);
                        nameEyes = recognizerEyes.Recognize(resultEyes);
                        if (name == nameEyes)
                        {
                            currentFrame.Draw(nameEyes, ref font, new Point(f.rect.X - 150, f.rect.Y - 35), new Bgr(Color.Red));
                        }
                        else
                        {
                            currentFrame.Draw("noname", ref font, new Point(f.rect.X - 150, f.rect.Y - 35), new Bgr(Color.Red));
                        }

                    }

                }
                else
                {


                    currentFrame.Draw("noname", ref font, new Point(f.rect.X - 150, f.rect.Y - 35), new Bgr(Color.Red));
                }

                NamePersons[t - 1] = name;
                NamePersonsEyes[t - 1] = nameEyes;
                NamePersons.Add("");
                NamePersonsEyes.Add("");


                //Set the number of faces detected on the scene
                label3.Text = facesDetected[0].Length.ToString();


                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);


                    //var Arrayeyes = eyesDetected[0];
                    // Arrayeyes[0].rect.X
                    if (eyesfocus)
                    {
                        currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 1);
                        if (eyeRect.X < f.rect.X + (f.rect.Width / 2))
                        {
                            currentFrame.Draw(new CircleF(new PointF(eyeRect.X, eyeRect.Y), 1), new Bgr(Color.Blue), 5);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X, eyeRect.Y), new Point(eyeRect.X - 100, eyeRect.Y)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X - 100, eyeRect.Y), new Point(eyeRect.X - 100, eyeRect.Y + 15)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X - 100, eyeRect.Y + 15), new Point(eyeRect.X - 170, eyeRect.Y + 15)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw("right eye", ref font, new Point(eyeRect.X - 185, eyeRect.Y + 10), new Bgr(Color.Blue));
                        }

                        else
                        {
                            currentFrame.Draw(new CircleF(new PointF(eyeRect.X + eyeRect.Width, eyeRect.Y), 1), new Bgr(Color.Blue), 5);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width, eyeRect.Y), new Point(eyeRect.X + eyeRect.Width, eyeRect.Y - 100)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width, eyeRect.Y - 100), new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 100)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 100), new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 90)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw(new LineSegment2D(new Point(eyeRect.X + eyeRect.Width + 40, eyeRect.Y - 90), new Point(eyeRect.X + eyeRect.Width + 140, eyeRect.Y - 90)), new Bgr(Color.Blue), 1);
                            currentFrame.Draw("left eye", ref font, new Point(eyeRect.X + eyeRect.Width + 45, eyeRect.Y - 95), new Bgr(Color.Blue));
                        }
                    }
                }
            }
            t = 0;
            tEyes = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
                namesEyes = namesEyes + NamePersonsEyes[nnn] + ", ";

            }


            //Show the faces procesed and recognized
            //  imageBoxFrameGrabber.Image = currentFrame.Flip(FLIP.HORIZONTAL);
            if (camlive)
            imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            nameEyes = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
            NamePersonsEyes.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //
        }



        public static Bitmap AdjustBrightness(Bitmap Image, int Value)
        {

            Bitmap TempBitmap = Image;

            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);

            Graphics NewGraphics = Graphics.FromImage(NewBitmap);

            float FinalValue = (float)Value / 255.0f;

            float[][] FloatColorMatrix ={

                     new float[] {1, 0, 0, 0, 0},

                     new float[] {0, 1, 0, 0, 0},

                     new float[] {0, 0, 1, 0, 0},

                     new float[] {0, 0, 0, 1, 0},

                     new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                 };

            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);

            ImageAttributes Attributes = new ImageAttributes();

            Attributes.SetColorMatrix(NewColorMatrix);

            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);

            Attributes.Dispose();

            NewGraphics.Dispose();

            return NewBitmap;
        }



    }
}