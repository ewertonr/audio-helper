# audio-helper [![Build Status](https://travis-ci.org/ewertonr/audio-helper.svg?branch=master)](https://travis-ci.org/ewertonr/audio-helper)

To generate small mp3 files, you must write a txt file following this template:

```{hours}:{minuts}:{seconds} - {song title}```

Example:
```
00:01:23 - Cigana
00:02:50 - Cheia de Manias
00:04:55 - É Tarde Demais
00:06:19 - Medida Exata
```

Also, you must have the MP3 file with the entire song and pass it as parameter.

### Example:

```sh
$ .exe "C:\audio-helper\songs.txt" "C:\audio-helper\dvd-raca-negra.mp3" 
```

On mp3 directory, will be created the directory "cd", your songs should be there. Enjoy! :musical_note:
