using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        // �������� XML ���������
        XmlDocument doc = new XmlDocument();

         // ���������� ������, ����������� ������ XML � ���������
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(xmlDeclaration);

        // ���������� ������, ����������� XML ���� � CSS ������
        XmlProcessingInstruction pi = doc.CreateProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"tt.css\"");
        doc.AppendChild(pi);

        XmlElement root = doc.CreateElement("telef");
        doc.AppendChild(root);

        // ������ ������ �� ���������� �����
        string[] lines = File.ReadAllLines("input.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            XmlElement phone = doc.CreateElement("tele");
            root.AppendChild(phone);

            XmlElement model = doc.CreateElement("��������");
            model.InnerText = parts[0].Trim();
            phone.AppendChild(model);

            XmlElement brand = doc.CreateElement("������������");
            brand.InnerText = parts[1].Trim();
            phone.AppendChild(brand);

            XmlElement color = doc.CreateElement("����");
            color.InnerText = parts[2].Trim();
            phone.AppendChild(color);

            XmlElement display = doc.CreateElement("�������");
            display.InnerText = parts[3].Trim();
            phone.AppendChild(display);

            XmlElement dimensions = doc.CreateElement("�������");
            dimensions.InnerText = parts[4].Trim();
            phone.AppendChild(dimensions);

            XmlElement year = doc.CreateElement("���");
            year.InnerText = parts[5].Trim();
            phone.AppendChild(year);

            XmlElement charging = doc.CreateElement("�������");
            charging.InnerText = parts[6].Trim();
            phone.AppendChild(charging);

            XmlElement battery = doc.CreateElement("�������");
            battery.InnerText = parts[7].Trim();
            phone.AppendChild(battery);

            XmlElement caseColor = doc.CreateElement("����_�����");
            caseColor.InnerText = parts[8].Trim();
            phone.AppendChild(caseColor);
        }

        // ���������� XML ���������
        doc.Save("��������.xml");

        // �������� CSS �����
        string css = "telef {display: table; width: 100%; border-collapse: collapse; background-color: #d8b1bf; } tele { display: table-row; } ��������, ������������, ����, �������, �������, ���, �������, �������, ����_����� { display: table-cell; padding: 15px; text-align: left; border-bottom: 1px solid #ddd; color: red;}";
        File.WriteAllText("tt.css", css);
    }
}
