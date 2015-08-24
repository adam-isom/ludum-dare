cat $1 | sed "s/^\(..*\)$/[\"\1\"],/" > temp_thing
tr '\n' ' ' < temp_thing > $1.formatted
rm temp_thing
