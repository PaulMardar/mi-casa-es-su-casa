#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_test_13.h"
#include "Service.h"
class test_13 : public QMainWindow
{
    Q_OBJECT

public:
    test_13(Service service,QWidget *parent = Q_NULLPTR);

private:
    Ui::test_13Class ui;
    Service service;
    void populate();
    void conection();
    void show_atributes();
    void filter();
};
