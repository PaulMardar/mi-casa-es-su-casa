#include <iostream>
#include <fstream>
#include "Htmlrepo.h"

Image image_from_parts(const std::vector<std::string>& parts) {
  auto id_image = parts.at(0);
  auto measurement_image = parts.at(1);
  auto clarity_level_image = parts.at(2);

  std::cout << "patrs.at(3): " << parts.at(3) << std::endl;
  auto quantity = std::stoi(parts.at(3));
  auto name = parts.at(4);

  return Image{id_image, measurement_image, clarity_level_image, quantity, name};
}

Image read_image_html(const std::vector<std::string>& lines, std::size_t current_index) {
  std::vector<std::string> parts;

  for (std::size_t i = current_index + 1; i < current_index + 6; ++i) {
    auto current_line = lines[i];

    auto trimmed_beginning = current_line.substr(10);
    auto trimmed_end = trimmed_beginning.substr(0, trimmed_beginning.size() - 5);

    parts.push_back(trimmed_end);
  }

  return image_from_parts(parts);
}

std::vector<Image> read_images_html(std::istream& html_stream) {
  std::string current_line;

  for (std::size_t i = 0; i < 14; ++i)
    std::getline(html_stream, current_line);

  std::vector<std::string> lines;

  while (std::getline(html_stream, current_line))
    lines.push_back(current_line);

  auto images_count = (lines.size() - 3) / 7;

  std::vector<Image> images;

  for (std::size_t i = 0, current_index = 0; i < images_count; ++i, current_index += 7)
    images.push_back(read_image_html(lines, current_index));

  return images;
}

std::vector<Image> Htmlrepo::load_from_file() {
  std::ifstream html_stream{filename};

  if (html_stream.good()) {
    auto vector = read_images_html(html_stream);
    return vector;
  }
  else
    return {};
}

void Htmlrepo::save_to_file(const std::vector<Image>& images) {
    std::ofstream html_stream(filename);
    html_stream << "<!DOCTYPE html>\n";
    html_stream << "<html>\n";
    html_stream << "<head>\n";
    html_stream << "   <title>MyList</title>\n";
    html_stream << "</head>\n";
    html_stream << "<body>\n";
    html_stream << "  <table border=\"1\">\n";
    html_stream << "    <tr>\n";
    html_stream << "      <td>Id</td>\n";
    html_stream << "      <td>Measurment</td>\n";
    html_stream << "      <td>Clarity Level</td>\n";
    html_stream << "      <td>Quantity</td>\n";
    html_stream << "      <td>Name</td>\n";
    html_stream << "    </tr>\n";


    std::cout << "images length: " << images.size() << std::endl;
    for (auto image : images) {
        html_stream << "    <tr>\n";
        html_stream << "      <td>" << image.get_id_image() << "</td>\n";
        html_stream << "      <td>" << image.get_measurement_image() << "</td>\n";
        html_stream << "      <td>" << image.get_clarity_level_image() << "</td>\n";
        html_stream << "      <td>" << image.get_quantity() << "</td>\n";
        html_stream << "      <td>" << image.get_name_image() << "</td>\n";
        html_stream << "    </tr>\n";
    }

    html_stream << "  </table>\n";
    html_stream << "</body>\n";
    html_stream << "</html>\n";
}