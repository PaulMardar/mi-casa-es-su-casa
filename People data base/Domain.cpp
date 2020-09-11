#include "Domain.h"

std::vector<std::string> splitLine(std::string initial_line, char delimiter)
{
	std::vector<std::string> pieces;
	std::stringstream initial(initial_line);
	std::string piece;
	while (std::getline(initial, piece, delimiter))
		pieces.push_back(piece);
	return pieces;
}


std::istream& operator>>(std::istream& instream, Domain& current)
{
	std::string one_line{};
	getline(instream, one_line);

	std::vector<std::string> separated_fields = splitLine(one_line, '|');
	if (separated_fields.size() == 0)
		return instream;

	current.set_body(separated_fields[0]);
	current.set_name(separated_fields[1]);
	current.set_calitati(separated_fields[2]);
	return instream;
}
std::ostream& operator<<(std::ostream& outstream, const Domain& current)
{
	outstream << current.body_type + " " + current.name + " " + current.calitati + " ";
	return outstream;
}
