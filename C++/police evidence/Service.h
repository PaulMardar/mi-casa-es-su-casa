#pragma once
#include <exception>
#include <memory>
#include <utility>
#include "Repo.h"
#include "Csvrepo.h"

class Wrong_mode_exception : public std::exception {};
class Invalid_Image_exception : public std::exception{};
class Invalid_extension_exception : public std::exception { };

class Service
{
protected:
	Csvrepo database;
	std::unique_ptr<FileRepo> watchlist;
	int currentIndex = -1;

	std::string mode;


public:
  Service() : database{""} { }

	void require_mode(const std::string& mode);
	void set_file(std::string filename_txt);
  void set_mylist_file(const std::string& filename);
  std::string get_mylist_filename();
	const std::string& get_mode();
	void set_mode(const std::string& mode);

	// mode a 
	bool addimage_service(const std::string& id_image, const std::string& measurment_image, const std::string& clarity_level_image, const int& quantity, const std::string& name);
	bool updateimage_service(const std::string& id_image, const std::string& measurment_image, const std::string& clarity_level_image, const int& quantity, const std::string& name);
	bool deleteimage_service(const std::string& id_image);
	std::vector<Image> get_all_images();   // list 

	// mode B 
	std::pair<bool, Image> next();
	bool save(const std::string& id_image);
	std::vector<Image> get_watchlist();



};
