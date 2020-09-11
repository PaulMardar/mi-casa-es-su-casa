#include "test_13.h"
#include "Domain.h"
test_13::test_13(Service service,QWidget *parent)
    : QMainWindow(parent),service{service}
{
    ui.setupUi(this);
    this->populate();
    this->conection();
}

void test_13::populate()
{
    auto all = service.get_all();
    for (auto i : all)
    {
        this->ui.listWidget->addItem(QString::fromStdString(i.get_body_type()) + " " + QString::fromStdString(i.get_name()));
    }
}

void test_13::conection()
{
    QObject::connect(this->ui.pushButton, &QPushButton::clicked, this, &test_13::show_atributes);
    QObject::connect(this->ui.pushButton_2, &QPushButton::clicked, this, &test_13::filter);
}

void test_13::show_atributes()
{
    std::string name_p;
    name_p = this->ui.lineEdit->text().toStdString();
    for (auto i : service.get_all())
    {
        if (i.get_name() == name_p)
        {
            this->ui.listWidget_2->addItem(QString::fromStdString(i.get_calitati()));
        }
    }
    
}

void test_13::filter()
{// this function just clears the previous populated widget list and populates it with partial matching form name and body type for a particualr profile
    this->ui.listWidget->clear();
    std::string input = this->ui.lineEdit_2->text().toStdString();
    auto all = service.get_all();
    for (auto i : all)
    { 
        std::size_t pos1 = i.get_name().find(input);
        std::size_t pos2 = i.get_body_type().find(input);
     
        // basicaly i just use the find function and compare the returns with an int if the return is < 6 then it means it is a match :)) , becouse if it is not it will return npos witch is a size _t and is > bigger than an normal single digit number 
        // no testing :((
        if (pos1 < 6 || pos2<6)
        {
            this->ui.listWidget->addItem(QString::fromStdString(i.get_body_type()) + " " + QString::fromStdString(i.get_name()));
        }
    }

}


void test_for_filter()
{
// test the find function ?
}