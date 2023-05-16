% Printer facts
printer(brother_dcp_t425w).
color_printer(brother_dcp_t425w).
inkjet_printer(brother_dcp_t425w).
wireless_printer(brother_dcp_t425w).
multifunction_printer(brother_dcp_t425w).

% Printer capabilities
can_print(brother_dcp_t425w, black_and_white).
can_print(brother_dcp_t425w, color).
can_scan(brother_dcp_t425w, black_and_white).
can_scan(brother_dcp_t425w, color).
can_copy(brother_dcp_t425w, black_and_white).
can_copy(brother_dcp_t425w, color).
can_print_via_wifi(brother_dcp_t425w).
can_print_via_usb(brother_dcp_t425w).

% Printer ink cartridge information
ink_cartridge(brother_dcp_t425w, black).
ink_cartridge(brother_dcp_t425w, cyan).
ink_cartridge(brother_dcp_t425w, magenta).
ink_cartridge(brother_dcp_t425w, yellow).

% Printer elements
printer_element(brother_dcp_t425w, power_cable).
printer_element(brother_dcp_t425w, usb_cable).
printer_element(brother_dcp_t425w, paper_tray).
printer_element(brother_dcp_t425w, paper).
printer_element(brother_dcp_t425w, printhead).

% Printer status
paper_inside(brother_dcp_t425w).

% Printer panel elements
% buttons
printer_panel_element(brother_dcp_t425w, power_on_button).
printer_panel_element(brother_dcp_t425w, start_color_button).
printer_panel_element(brother_dcp_t425w, start_mono_button).
printer_panel_element(brother_dcp_t425w, fast_copy_button).
printer_panel_element(brother_dcp_t425w, start_mono_button).

printer_panel_element(brother_dcp_t425w, led_diode_power).
printer_panel_element(brother_dcp_t425w, led_diode_warinig).
printer_panel_element(brother_dcp_t425w, ink_led_diode).

printer_panel_element(brother_dcp_t425w, wifi_diode_button).



% knowledge base

%specific error can be fixed with action

% LED states representing error states

% led_state(Error, Power, Warning, Ink)
led_state(not_plugged_in, off, off, off).
led_state(turned_off, off, off, off).
led_state(paper_jam, blink, blink, off).
led_state(no_paper, on, on, off).
led_state(paper_tray_not_inserted, on, on, off).
led_state(incorrect_paper_size, on, blink, off).
% naciagane
led_state(dirty_printhead, blink, blink, blink).



%  Error results in a secific state
problem(no_power, not_plugged_in). % drukarka nie jest podłączona do prądu
problem(no_power, turned_off). % drukarka wyłączona
problem(paper_jam, dont_print). % zacięcie papieru
problem(no_paper, dont_print). % brak papieru
problem(incorrect_paper_size, dont_print). % nieprawidłowy rozmiar papieru
problem(paper_tray_not_inserted, dont_print). % nieprawidłowy rozmiar papieru
problem(dirty_printhead, bad_print). % zła jakość wydruku


% Element causes a specifc Error 
cause(power_cable, no_power). % kabel zasilający nie jest podłączony
cause(paper, no_paper). % brak papieru
cause(paper_tray, paper_tray_not_inserted). % taca na papier nie jest włożona
cause(paper, incorrect_paper_size). % papier nie pasuje do drukarki
cause(paper, paper_jam). % papier powoduje zacięcie papieru
cause(printhead, dirty_printhead). % głowica drukująca jest zanieczyszczona

% solution
fix(no_paper, 'insert a paper').
fix(not_plugged_in, 'insert a power cable').
fix(not_plugged_in, 'insert a power cable').
fix(paper_tray_not_inserted, 'insert a paper tray properly').


% led_state(ERROR, blink, blink, off), cause(ELEMENT, ERROR).

define_error(Power, Warn, Ink, ERROR) :-
    led_state(ERROR, Power, Warn, Ink).
% define_error(off, off, off).


define_element(Power, Warn, Ink, ELEMENT) :-
    led_state(ERROR, Power, Warn, Ink),
    problem(STATE, ERROR),
    cause(ELEMENT, STATE).

%define_element(off, off, off, ELEMENT).


define_solution(STATE, ACTION) :-
    fix(STATE, ACTION).
    

troubleshoot(Power, Warn, Ink, ACTION) :-
    define_error(Power, Warn, Ink, ERROR),
    define_solution(ERROR,ACTION).
    

on(led_diode_power).
blinks(warning_led_diode).

paper_jam(led_diode_power, warning_led_diode) :-
    blinks(led_diode_power),
    blinks(warning_led_diode).

no_paper(led_diode_power, warning_led_diode) :-
    on(led_diode_power),
    on(warning_led_diode).

cos(Error):-
    problem(Error, Element1),
    problem(Error, Element2),
    Element1 \= Element2.