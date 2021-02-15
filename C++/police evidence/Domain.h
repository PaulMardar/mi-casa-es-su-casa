#pragma once
#include <algorithm>
#include <string>

class Image
{
protected:
	std::string id_image;
	std::string measurment_image;
	std::string clarity_level_image;
	int quantity;
	std::string name;

public:
	Image();   // constructor de nimika
	Image(std::string id, std::string measurment_image, std::string clarity_level_image, int quantity, std::string name); // constructor
	Image(const Image& other_image);

	std::string get_id_image() const;
	std::string get_measurement_image() const;
	std::string get_clarity_level_image() const;
	std::string get_name_image() const;
	int get_quantity() const;

	void set_id_image(const std::string& new_id) { this->id_image = new_id; }
	void set_measurment_image(const std::string& new_mesurment_image) { this->measurment_image = new_mesurment_image; }
	void set_clarity_level_image(const std::string& new_clarity_level) { this->clarity_level_image = new_clarity_level; }
	void set_quantity(const int& new_quantity) { this->quantity = new_quantity; }
	void set_name(const std::string& new_name) { this->name = new_name; }

	friend std::ostream& operator <<(std::ostream& out, const Image& entity);
	friend std::istream& operator >>(std::istream& in, Image& entity);

	Image& operator =(const Image& other_image);
	bool operator==(const Image& image_to_compare);

};

inline void trim_string(std::string& string) {
	auto isNotSpace = [](char character) { return !std::isspace(character); };
	string.erase(string.begin(), std::find_if(string.begin(), string.end(), isNotSpace));
	string.erase(std::find_if(string.rbegin(), string.rend(), isNotSpace).base(), string.end());
}
