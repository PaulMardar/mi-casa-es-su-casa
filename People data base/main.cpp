#include "test_13.h"
#include <QtWidgets/QApplication>
#include "Service.h"
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    Repo repo{ "in.txt" };
    Service serv{ repo };
    test_13 w{ serv };
    w.show();
    return a.exec();
}
