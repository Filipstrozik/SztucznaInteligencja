/*
Drukarka to Brother DCP-T425W, stoi na komodzie w moim pokoju,
a instrukcja obsługi była podstawą do zrealizowania tej listy.
Instrukcja jest zatytułowana "Podręcznik szybkiej obsługi".
Drukarka posiada takie elementy jak: 
- kabel zasilający
- kabel USB
- taca na papier
- papier
- głowica drukująca
- tusz black
- tusz cyan
- tusz magenta
- tusz yellow
Drukarka posiada takie przyciski jak:
- przycisk włączania
- przycisk kopiowania w kolorze
- przycisk kopiowania w czerni
- przycisk szybkiego kopiowania
- przycisk drukowania w czerni
Drukarka posiada takie diody jak:
- dioda zasilania
- dioda ostrzegawcza
- dioda tuszu
- dioda wifi

Po któtkiej lekturze możemy trafic na strone roziwązywania problemów, która zawiera takie informacje jak:
opis przycisków oraz diód:
- 1. - przycisk włączania
- 2. - dioda led zasilania
- 3. - dioda led ostrzegawcza
- 4. - dioda led atramentu
- 5. - przycisk kopiowania w kolorze
- 6. - przycisk kopiowania w czerni
- 7. - przycisk szybkiego kopiowania
- 8. - przycisk / dioda LED Wi-Fi
Również możemy znaleźć informacje o tym jakie błędy mogą wystąpić oraz jak je rozwiązać na podstawie kombinacji swiecenia diód.
Dostępne są trzy stany diod: 
- wyłączona
- włączona
- miganie

Obrazkami przedstawione są następujące stany diod oraz ich probelemy:
1.
- dioda zasilania - wyłączona
- dioda ostrzegawcza - wyłączona
- dioda tuszu - wyłączona
- problem - drukarka nie jest podłączona do prądu
- element - kabel zasilający

2.
- dioda zasilania - wyłączona
- dioda ostrzegawcza - wyłączona
- dioda tuszu - wyłączona
- problem - drukarka jest wyłączona
- element - przycisk włączania

3.
- dioda zasilania - miganie
- dioda ostrzegawcza - miganie
- dioda tuszu - wyłączona
- problem - zacięcie papieru
- element - papier

4.
- dioda zasilania - włączona
- dioda ostrzegawcza - włączona
- dioda tuszu - wyłączona
- problem - brak papieru
- element - papier

5.
- dioda zasilania - włączona
- dioda ostrzegawcza - miganie
- dioda tuszu - wyłączona
- problem - zły rozmiar papieru
- element - papier
*/

% Printer information
% Fakty o drukarce - które udało się wywnioskować z instrukcji
printer(brother_dcp_t425w).
color_printer(brother_dcp_t425w).
inkjet_printer(brother_dcp_t425w).
wireless_printer(brother_dcp_t425w).
multifunction_printer(brother_dcp_t425w).

% Printer capabilities
% Fakty o możliwościach drukarki - które udało się wywnioskować 
% z dostepnych funkcji oraz samych przycisków
can_print(brother_dcp_t425w, black_and_white).
can_print(brother_dcp_t425w, color).
can_scan(brother_dcp_t425w, black_and_white).
can_scan(brother_dcp_t425w, color).
can_copy(brother_dcp_t425w, black_and_white).
can_copy(brother_dcp_t425w, color).
can_print_via_wifi(brother_dcp_t425w).
can_print_via_usb(brother_dcp_t425w).

% Printer ink cartridge information
% Fakty o tuszach oraz ich numerach
ink_cartridge(black_ink_cartidge, btD60BK).
ink_cartridge(cyan_ink_cartidge, bt5000C).
ink_cartridge(magenta_ink_cartidge, bt5000M).
ink_cartridge(yellow_ink_cartidge, bt5000Y).

% Printer elements
% Fakty o elementach drukarki
printer_element(power_cable).
printer_element(usb_cable).
printer_element(paper_tray).
printer_element(paper).
printer_element(printhead).
printer_element(black_ink_cartridge).
printer_element(cyan_ink_cartridge).
printer_element(yellow_ink_cartridge).
printer_element(magenta_ink_cartridge).

% Printer panel elements
% Fakty o elementach panelu drukarki
printer_panel_element(power_button).
printer_panel_element(start_color_button).
printer_panel_element(start_mono_button).
printer_panel_element(fast_copy_button).
printer_panel_element(start_mono_button).

% Status Diodes
% Fakty o diodach
printer_panel_element(led_diode_power).
printer_panel_element(led_diode_warinig).
printer_panel_element(ink_led_diode).
printer_panel_element(wifi_diode_button).

/*
Mając te infromacje, możemy wokonywać proste zapytania, 
które będą odpowiadć na pytania typu:
- czy drukarka jest bezprzewodowa?
- w jaki sposób można drukować?
- czy można skanować na drukarce?
- jaki jest numer tuszu czarnego
- jakie elementy posiada drukarka?

Przykładowe zapytania:
?- wireless_printer(brother_dcp_t425w).
?- can_print(brother_dcp_t425w, TRYB).
?- can_scan(brother_dcp_t425w, color).
?- ink_cartridge(black_ink_cartidge, NUMER).
?- printer_element(ELEMENT).

Wszystkie zapytania zwrócą wartość true, ponieważ są to fakty o drukarce.
Gdybyśmy mieli fakty o wielu drukarkach, to moglibyśmy poniekąd tworzyć zapytania w celu znalezenia 
drukarki o określonych właściwościach, np.:
?- wireless_printer(PRINTER), can_print(PRINTER, color), can_scan(PRINTER, color).
Zapytanie to zwróciłoby nam wszystkie drukarki, które posiadają możliwość drukowania w kolorze oraz skanowania w kolorze.
W naszym przypadku zwróciłoby to tylko jedną drukarkę, ponieważ tylko jedna z nich spełnia te warunki.
*/


% LED states representing error states
% Fakty o stanach diod, które odpowiadają za błędy
% led_state(Error, Power, Warning, Ink)
led_state(not_plugged_in, off, off, off).
led_state(turned_off, off, off, off).
led_state(paper_jam, blink, blink, off).
led_state(no_paper, on, on, off).
led_state(paper_tray_not_inserted, on, on, off).
led_state(incorrect_paper_size, on, blink, off).


% Error results in a secific state
% Fakty o błędach, które powodują wystąpienie konkretnego stanu diod
problem(no_power, not_plugged_in). % drukarka nie jest podłączona do prądu
problem(off, turned_off). % drukarka wyłączona
problem(dont_print, paper_jam). % zacięcie papieru
problem(dont_print, no_paper). % brak papieru
problem(dont_print, incorrect_paper_size). % nieprawidłowy rozmiar papieru
problem(dont_print, paper_tray_not_inserted). % nieprawidłowy rozmiar papieru

print_problem(bad_quality, dirty_printhead). % zła jakość wydruku
print_problem(good_quality_but_no_color, low_cyan_ink). % zła jakość wydruku
print_problem(good_quality_but_no_color, low_magenta_ink). % zła jakość wydruku
print_problem(good_quality_but_no_color, low_yellow_ink). % zła jakość wydruku
print_problem(good_quality_but_no_color, low_black_ink). % zła jakość wydruku


% Element causes a specifc Error 
% Fakty o elementach, które powodują wystąpienie konkretnego błędu
cause(power_cable, no_power, not_plugged_in). % kabel zasilający nie jest podłączony
cause(power_button, off, turned_off). % kabel zasilający nie jest podłączony
cause(paper, dont_print, no_paper). % brak papieru
cause(paper_tray, dont_print, paper_tray_not_inserted). % taca na papier nie jest włożona
cause(paper, dont_print, incorrect_paper_size). % papier nie pasuje do drukarki
cause(paper, dont_print, paper_jam). % papier powoduje zacięcie papieru
cause(printhead, bad_quality, dirty_printhead). % głowica drukująca jest zanieczyszczona
cause(cyan_ink_cartridge, good_quality_but_no_color, low_cyan_ink). % brak tuszu cyan
cause(magenta_ink_cartridge, good_quality_but_no_color, low_magenta_ink). % brak tuszu magenta
cause(yellow_ink_cartridge, good_quality_but_no_color, low_yellow_ink). % brak tuszu yellow
cause(black_ink_cartridge, good_quality_but_no_color, low_black_ink). % brak tuszu black

% Solutions to problems
% Fakty o rozwiązaniach problemów
fix(no_paper, 'insert a paper').
fix(not_plugged_in, 'insert a power cable').
fix(turned_off, 'turn on a printer').
fix(paper_tray_not_inserted, 'insert a paper tray properly').
fix(incorrect_paper_size, 'insert a proper paper size').
fix(paper_jam, 'remove a paper jam').
fix(dirty_printhead, 'clean a printhead').
fix(low_cyan_ink, 'fill up cyan ink cartridge').
fix(low_magenta_ink, 'fill up magenta ink cartridge').
fix(low_yellow_ink, 'fill up yellow ink cartridge').
fix(low_black_ink, 'fill up black ink cartridge').

% Troubleshooting rules
% Reguły rozwiązywania problemów
define_error_by_led(POWER, WARN, INK, ERROR) :-
    led_state(ERROR, POWER, WARN, INK).

define_element(POWER, WARN, INK, ELEMENT) :-
    define_error_by_led(POWER, WARN, INK, ERROR),
    problem(STATE, ERROR),
    cause(ELEMENT, STATE, ERROR),
    (\+ printer_element(ELEMENT), printer_panel_element(ELEMENT)).
    
define_printing_element(PRINT_QLTY, ELEMENT) :-
    print_problem(PRINT_QLTY, ERROR),
    cause(ELEMENT, PRINT_QLTY, ERROR),
    printer_element(ELEMENT).

define_solution(ERROR, ACTION) :-
    fix(ERROR, ACTION).

troubleshoot(POWER, WARN, INK, ACTION) :-
    define_error_by_led(POWER, WARN, INK, ERROR),
    define_solution(ERROR,ACTION).

troubleshoot_printing_quality(PRINT_QLTY, ACTION) :-
    print_problem(PRINT_QLTY, ERROR),
    define_solution(ERROR,ACTION).

/*
Dzięki tym predykatom możemy określić, które elementy drukarki powodują wystąpienie błędu
oraz jakie rozwiązanie jest potrzebne, aby go naprawić.
Dodatkowo możemy określić, które elementy drukarki powodują wystąpienie błędu w jakości wydruku
oraz jakie rozwiązanie jest potrzebne, aby go naprawić.

Przykładowe zapytania:
 - możemy sprawdzić jaki stan diod odpowiada problemowi:
    define_error_by_led(on, blink, off, ERROR).
    define_error_by_led(POWER, WARN, INK, paper_jam).
 - możemy sprawdzić, które elementy powodują wystąpienie błędu:
    ?- define_element(off, off, off, ELEMENT).
    ?- define_element(on, on, off, ELEMENT).
    ?- define_element(blink, blink, off, ELEMENT).
    ?- define_element(POWER, WARN, INK, incorrect_paper_size).
 - możemy zdefiniować, które elementy powodują wystąpienie błędu w jakości wydruku:
    ?- define_printing_element(bad_quality, ELEMENT).
    ?- define_printing_element(good_quality_but_no_color, ELEMENT).
 - możemy zdefiniować, jakie czynności są wymagane do naprawy konkretnego błedu:
    ?- define_solution(incorrect_paper_size, ACTION).
    ?- define_solution(dirty_printhead, ACTION).
    ?- define_solution(low_black_ink, ACTION).
 - możemy wnioskować jaka czynność jest potrzebna podając stany diod:
    ?- troubleshoot(off, off, off, ACTION).
    ?- troubleshoot(on, on, off, ACTION).
    ?- troubleshoot(blink, blink, off, ACTION).
 - możemy wnioskować jaka czynność jest potrzebna określając jakość wydruku:
    ?- troubleshoot_printing_quality(bad_quality, ACTION).
    ?- troubleshoot_printing_quality(good_quality_but_no_color, ACTION).
*/

troubleshoot_script :-
    write('Is the printer printing?'), nl,
    read(Answer),
    (Answer = n ->
        write('What is the state of the Power diode? (on / blink / off)'), nl,
        read(Power),
        write('What is the state of the Warn diode? (on / blink / off)'), nl,
        read(Warn),
        write('What is the state of the Ink diode? (on / blink / off)'), nl,
        read(Ink),
        troubleshoot(Power, Warn, Ink, ACTION),
        write(ACTION), nl
    ;
    Answer = y ->
        write('What is the quality of printing? (bad_quality / good_quality_but_no_color)'), nl,
        read(Quality),
        troubleshoot_printing_quality(Quality, ACTION),
        write(ACTION), nl
    ).