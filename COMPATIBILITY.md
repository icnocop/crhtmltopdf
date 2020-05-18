Supported command line options when compared with https://wkhtmltopdf.org/usage/wkhtmltopdf.txt.

| Command Line Option            | Supported          | Notes                                                                                  |
| ------------------------------ | ------------------ | -------------------------------------------------------------------------------------- |
| cover                          | :heavy_check_mark: |                                                                                        |
| toc                            | :x:                |                                                                                        |
| --collate                      | :x:                |                                                                                        |
| --no-collate                   | :x:                |                                                                                        |
| --cookie-jar                   | :x:                |                                                                                        |
| --copies                       | :x:                |                                                                                        |
| -d, --dpi                      | :x:                |                                                                                        |
| -H, --extended-help            | :x:                |                                                                                        |
| -g, --grayscale                | :x:                |                                                                                        |
| -h, --help                     | :white_check_mark: | Only `--help` is supported.                                                            |
| --htmldoc                      | :x:                |                                                                                        |
| --image-dpi                    | :x:                |                                                                                        |
| --image-quality                | :x:                |                                                                                        |
| --license                      | :x:                |                                                                                        |
| --log-level                    | :heavy_check_mark: | Added an additional `Debug` log level.                                                 |
| -l, --lowquality               | :x:                |                                                                                        |
| --manpage                      | :x:                |                                                                                        |
| -B, --margin-bottom            | :heavy_check_mark: |                                                                                        |
| -L, --margin-left              | :heavy_check_mark: |                                                                                        |
| -R, --margin-right             | :heavy_check_mark: |                                                                                        |
| -T, --margin-top               | :heavy_check_mark: |                                                                                        |
| -O, --orientation              | :heavy_check_mark: |                                                                                        |
| --page-height                  | :heavy_check_mark: |                                                                                        |
| -s, --page-size                | :heavy_check_mark: |                                                                                        |
| --page-width                   | :heavy_check_mark: |                                                                                        |
| --no-pdf-compression           | :x:                |                                                                                        |
| -q, --quiet                    | :heavy_check_mark: |                                                                                        |
| --read-args-from-stdin         | :heavy_check_mark: |                                                                                        |
| --readme                       | :x:                |                                                                                        |
| --title                        | :x:                |                                                                                        |
| --use-xserver                  | :x:                |                                                                                        |
| -V, --version                  | :white_check_mark: | Only `--version` is supported.                                                         |
| --dump-default-toc-xsl         | :x:                |                                                                                        |
| --dump-outline                 | :x:                |                                                                                        |
| --outline                      | :x:                |                                                                                        |
| --no-outline                   | :heavy_check_mark: |                                                                                        |
| --outline-depth                | :x:                |                                                                                        |
| --allow                        | :x:                |                                                                                        |
| --background                   | :heavy_check_mark: |                                                                                        |
| --no-background                | :heavy_check_mark: |                                                                                        |
| --bypass-proxy-for             | :x:                |                                                                                        |
| --cache-dir                    | :x:                |                                                                                        |
| --checkbox-checked-svg         | :x:                |                                                                                        |
| --checkbox-svg                 | :x:                |                                                                                        |
| --cookie                       | :x:                |                                                                                        |
| --custom-header                | :x:                |                                                                                        |
| --custom-header-propagation    | :x:                |                                                                                        |
| --no-custom-header-propagation | :x:                |                                                                                        |
| --debug-javascript             | :x:                |                                                                                        |
| --no-debug-javascript          | :x:                |                                                                                        |
| --default-header               | :x:                |                                                                                        |
| --encoding                     | :heavy_check_mark: |                                                                                        |
| --disable-external-links       | :x:                |                                                                                        |
| --enable-external-links        | :x:                |                                                                                        |
| --disable-forms                | :x:                |                                                                                        |
| --enable-forms                 | :x:                |                                                                                        |
| --images                       | :x:                |                                                                                        |
| --no-images                    | :x:                |                                                                                        |
| --disable-internal-links       | :x:                |                                                                                        |
| --enable-internal-links        | :x:                |                                                                                        |
| -n, --disable-javascript       | :x:                |                                                                                        |
| --enable-javascript            | :x:                |                                                                                        |
| --javascript-delay             | :heavy_check_mark: |                                                                                        |
| --keep-relative-links          | :x:                |                                                                                        |
| --load-error-handling          | :x:                |                                                                                        |
| --load-media-error-handling    | :x:                |                                                                                        |
| --disable-local-file-access    | :x:                |                                                                                        |
| --enable-local-file-access     | :x:                |                                                                                        |
| --minimum-font-size            | :x:                |                                                                                        |
| --exclude-from-outline         | :x:                |                                                                                        |
| --include-in-outline           | :x:                |                                                                                        |
| --page-offset                  | :x:                |                                                                                        |
| --password                     | :x:                |                                                                                        |
| --disable-plugins              | :x:                |                                                                                        |
| --enable-plugins               | :x:                |                                                                                        |
| --post                         | :x:                |                                                                                        |
| --post-file                    | :x:                |                                                                                        |
| --print-media-type             | :x:                |                                                                                        |
| --no-print-media-type          | :x:                |                                                                                        |
| -p, --proxy                    | :x:                |                                                                                        |
| --proxy-hostname-lookup        | :x:                |                                                                                        |
| --radiobutton-checked-svg      | :x:                |                                                                                        |
| --radiobutton-svg              | :x:                |                                                                                        |
| --resolve-relative-links       | :x:                |                                                                                        |
| --run-script                   | :x:                |                                                                                        |
| --disable-smart-shrinking      | :x:                |                                                                                        |
| --enable-smart-shrinking       | :x:                |                                                                                        |
| --ssl-crt-path                 | :x:                |                                                                                        |
| --ssl-key-password             | :x:                |                                                                                        |
| --ssl-key-path                 | :x:                |                                                                                        |
| --stop-slow-scripts            | :x:                |                                                                                        |
| --no-stop-slow-scripts         | :x:                |                                                                                        |
| --disable-toc-back-links       | :x:                |                                                                                        |
| --enable-toc-back-links        | :x:                |                                                                                        |
| --user-style-sheet             | :heavy_check_mark: |                                                                                        |
| --username                     | :x:                |                                                                                        |
| --viewport-size                | :x:                |                                                                                        |
| --window-status                | :x:                |                                                                                        |
| --zoom                         | :x:                |                                                                                        |
| --footer-center                | :x:                |                                                                                        |
| --footer-font-name             | :x:                |                                                                                        |
| --footer-font-size             | :x:                |                                                                                        |
| --footer-html                  | :x:                |                                                                                        |
| --footer-left                  | :x:                |                                                                                        |
| --footer-line                  | :x:                |                                                                                        |
| --no-footer-line               | :x:                |                                                                                        |
| --footer-right                 | :white_check_mark: | Only the `[page]`, `[date]`, `[title]`, and `[webpage]` variables are supported.       |
| --footer-spacing               | :x:                |                                                                                        |
| --header-center                | :x:                |                                                                                        |
| --header-font-name             | :x:                |                                                                                        |
| --header-font-size             | :x:                |                                                                                        |
| --header-html                  | :x:                |                                                                                        |
| --header-left                  | :x:                |                                                                                        |
| --header-line                  | :x:                |                                                                                        |
| --no-header-line               | :x:                |                                                                                        |
| --header-right                 | :x:                |                                                                                        |
| --header-spacing               | :x:                |                                                                                        |
| --replace                      | :x:                |                                                                                        |
| --disable-dotted-lines         | :x:                |                                                                                        |
| --toc-header-text              | :x:                |                                                                                        |
| --toc-level-indentation        | :x:                |                                                                                        |
| --disable-toc-links            | :x:                |                                                                                        |
| --toc-text-size-shrink         | :x:                |                                                                                        |
| --xsl-style-sheet              | :x:                |                                                                                        |