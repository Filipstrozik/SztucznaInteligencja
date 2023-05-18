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

    Po któtkiej lekurze możemy trafic na strone roziwązywania problemów, która zawiera takie informacje jak:
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
    
    (naciaganie)
    6.
    - dioda zasilania - miganie
    - dioda ostrzegawcza - miganie
    - dioda tuszu - miganie
    - problem - zanieczyszczona głowica drukująca
    - element - głowica drukująca

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
printer_element(black_ink_cartidge).
printer_element(cyan_ink_cartidge).
printer_element(yellow_ink_cartidge).
printer_element(magenta_ink_cartidge).

% Printer panel elements
% Fakty o elementach panelu drukarki
printer_panel_element(brother_dcp_t425w, power_on_button).
printer_panel_element(brother_dcp_t425w, start_color_button).
printer_panel_element(brother_dcp_t425w, start_mono_button).
printer_panel_element(brother_dcp_t425w, fast_copy_button).
printer_panel_element(brother_dcp_t425w, start_mono_button).

% Status Diodes
% Fakty o diodach
printer_panel_element(brother_dcp_t425w, led_diode_power).
printer_panel_element(brother_dcp_t425w, led_diode_warinig).
printer_panel_element(brother_dcp_t425w, ink_led_diode).
printer_panel_element(brother_dcp_t425w, wifi_diode_button).

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

    Wracając, mając zdefiniowane elementy drukarki, dzięki opisom stanów drukarki w instrukcji, możemy zdefiniować,
    które elementy powodują wystąpienie błędu, a które nie. To przy opisie stanów drukarki za pomocą diod, pozwoli 
    na określenie, które elementy są przyczyną wystąpienia błędu i w jaki sposób można mu zaradzić.

*/


% LED states representing error states
% Fakty o stanach diod, które odpowiadają za błędy
% led_state(Error, Power, Warning, Ink)

led_state(turned_off, off, off, off).
led_state(paper_jam, blink, blink, off).
led_state(no_paper, on, on, off).
led_state(paper_tray_not_inserted, on, on, off).
led_state(incorrect_paper_size, on, blink, off).
% naciagane
%led_state(dirty_printhead, blink, blink, blink).

% printer just works



% Error results in a secific state
% Fakty o błędach, które powodują wystąpienie konkretnego stanu diod
problem(not_plugged_in, turned_off). % drukarka nie jest podłączona do prądu
problem(off, turned_off). % drukarka wyłączona
problem(dont_print, paper_jam). % zacięcie papieru
problem(dont_print, no_paper). % brak papieru
problem(incorrect_paper_size, dont_print). % nieprawidłowy rozmiar papieru
problem(paper_tray_not_inserted, dont_print). % nieprawidłowy rozmiar papieru

problem(dirty_printhead, bad_print). % zła jakość wydruku
problem(low_cyan_ink, bad_print). % zła jakość wydruku
problem(low_magenta_ink, bad_print). % zła jakość wydruku
problem(low_yellow_ink, bad_print). % zła jakość wydruku
problem(low_black_ink, bad_print). % zła jakość wydruku


% Element causes a specifc Error 
% Fakty o elementach, które powodują wystąpienie konkretnego błędu
cause(power_cable, not_plugged_in). % kabel zasilający nie jest podłączony
cause(power_button, off). % kabel zasilający nie jest podłączony
cause(paper, no_paper). % brak papieru
cause(paper_tray, paper_tray_not_inserted). % taca na papier nie jest włożona
cause(paper, incorrect_paper_size). % papier nie pasuje do drukarki
cause(paper, paper_jam). % papier powoduje zacięcie papieru
cause(printhead, dirty_printhead). % głowica drukująca jest zanieczyszczona
cause(cyan_ink_cartridge, low_cyan_ink). % brak tuszu cyan
cause(magenta_ink_cartridge, low_magenta_ink). % brak tuszu magenta
cause(yellow_ink_cartridge, low_yellow_ink). % brak tuszu yellow
cause(black_ink_cartridge, low_black_ink). % brak tuszu black

% Solutions to problems
% Fakty o rozwiązaniach problemów
fix(no_paper, 'insert a paper').
fix(not_plugged_in, 'insert a power cable').
fix(turned_off, 'turn on a printer').
fix(paper_tray_not_inserted, 'insert a paper tray properly').
fix(incorrect_paper_size, 'insert a proper paper size').
fix(paper_jam, 'remove a paper jam').
fix(dirty_printhead, 'clean a printhead').




% led_state(ERROR, blink, blink, off), cause(ELEMENT, ERROR).

define_error(Power, Warn, Ink, ERROR) :-
    led_state(ERROR, Power, Warn, Ink).
% define_error(off, off, off).

working('nothing to do, printer wo').





define_element(Power, Warn, Ink, ELEMENT) :-
    (led_state(ERROR, Power, Warn, Ink),
    problem(STATE, ERROR),
    cause(ELEMENT, STATE)).


/*
define_element(Power, Warn, Ink, ELEMENT) :-
    ((led_state(ERROR, Power, Warn, Ink),
    problem(STATE, ERROR)),
    cause(ELEMENT, STATE));
    ( \+ led_state(_, Power, Warn, Ink), 
    problem(STATE, bad_print),
    cause(ELEMENT, STATE)).
*/

%define_element(off, off, off, ELEMENT).


define_solution(ERROR, ACTION) :-
    fix(ERROR, ACTION).
    

troubleshoot(Power, Warn, Ink, ACTION) :-
    (define_error(Power, Warn, Ink, ERROR),
    define_solution(ERROR,ACTION));
    working(ACTION).
    

% cause(X,Y), problem(Y, bad_print), led_state(Y, blink, blink, blink).



cos(Error):-
    problem(Error, Element1),
    problem(Error, Element2),
    Element1 \= Element2.