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
printer_panel_element(brother_dcp_t425w, power_on_button).
printer_panel_element(brother_dcp_t425w, led_diode_power).
printer_panel_element(brother_dcp_t425w, warning_led_diode).
printer_panel_element(brother_dcp_t425w, ink_led_diode).
printer_panel_element(brother_dcp_t425w, start_color_button).
printer_panel_element(brother_dcp_t425w, start_mono_button).
printer_panel_element(brother_dcp_t425w, fast_copy_button).
printer_panel_element(brother_dcp_t425w, wifi_diode_button).



% knowledge base

% State Problem
problem(dont_work, not_plugged_in). % drukarka nie jest podłączona do prądu
problem(error5, paper_jam). % zacięcie papieru
problem(error5, no_paper). % brak papieru
problem(dont_work, incorrect_paper_size). % nieprawidłowy rozmiar papieru
problem(dont_work, paper_tray_not_inserted). % nieprawidłowy rozmiar papieru
problem(bad_print, dirty_printhead). % zła jakość wydruku


% Element Cause
cause(power_cable, dont_work). % kabel zasilający nie jest podłączony
cause(paper, no_paper). % brak papieru
cause(paper_tray, paper_tray_not_inserted). % taca na papier nie jest włożona
cause(paper, incorrect_paper_size). % papier nie pasuje do drukarki
cause(paper, paper_jam). % papier powoduje zacięcie papieru
cause(printhead, dirty_printhead). % głowica drukująca jest zanieczyszczona

% Panel Element State
% each diode can be on or off or blinking
% when led_diode_power and warning_led_diode are blinking then it means that printer dont work and it caused by no paper or no paper tray
% write a predicate that will check if printer dont work and it caused by no paper or no paper tray



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