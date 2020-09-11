#include <string>
#include <iostream>
#include <sstream>
#include "Domain.h"

Image::Image() : id_image(""), measurment_image(""), clarity_level_image(""), quantity(0), name("") {}


Image::Image(std::string id, std::string measurment_image, std::string clarity_level_image, int quantity, std::string name)
{
	this->id_image = id;
	this->measurment_image = measurment_image;
	this->clarity_level_image = clarity_level_image;
	this->quantity = quantity;
	this->name = name;
}

Image::Image(const Image& other_image)
{
	this->id_image = other_image.id_image;
	this->measurment_image = other_image.measurment_image;
	this->clarity_level_image = other_image.clarity_level_image;
	this->quantity = other_image.quantity;
	this->name = other_image.name;
}

std::string Image::get_id_image() const
{
	return this->id_image;
}

std::string Image::get_measurement_image() const
{
	return this->measurment_image;
}

std::string Image::get_clarity_level_image() const
{
	return this->clarity_level_image;
}

std::string Image::get_name_image() const
{
	return this->name;
}

int Image::get_quantity() const
{
	return this->quantity;
}

Image& Image::operator=(const Image& other_image)
{
	this->id_image = other_image.id_image;
	this->measurment_image = other_image.measurment_image;
	this->clarity_level_image = other_image.clarity_level_image;
	this->quantity = other_image.quantity;
	this->name = other_image.name;

	return *this;
}

bool Image::operator==(const Image& image_to_compare)
{
	if (this->id_image == image_to_compare.get_id_image())
		return true;
	return false;
}

std::ostream& operator<<(std::ostream& out, const Image& entity)
{
	out << entity.id_image << ", ";
	out << entity.measurment_image << ", ";
	out << entity.clarity_level_image << ", ";
	out << entity.quantity << ", ";
	out << entity.name;

	return out;
	// TODO: insert return statement here
}


std::istream& operator>>(std::istream& in, Image& entity)
{
	std::string line;
	std::getline(in, line);
	trim_string(line);
	if (line == "")
		return in;
	std::stringstream ss(line);
	std::getline(ss, entity.id_image, ',');
	std::getline(ss, entity.measurment_image, ',');
	std::getline(ss, entity.clarity_level_image, ',');
	std::string quantity_string;
	std::getline(ss, quantity_string, ',');
	std::getline(ss, entity.name);

	entity.quantity = std::stoi(quantity_string);
	trim_string(entity.id_image);
	trim_string(entity.measurment_image);
	trim_string(entity.clarity_level_image);
	trim_string(entity.name);
	return in;
}

