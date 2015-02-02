<?php 
header('Content-type: text/xml');

if ($_GET["d"] != "Silverlight") {
	echo "not Silverlight";
	return;
}

$xmlDoc = new DOMDocument('1.0', 'UTF-8'); 
$xmlDoc->formatOutput = true;

$tt = $xmlDoc->createElement('tt');

$tt->setAttribute('xml:lang', '');
$tt->setAttribute('xmlns', 'http://www.w3.org/ns/ttml');
$tt->setAttribute('xmlns:tts', 'http://www.w3.org/ns/ttml#styling');

$head = $xmlDoc->createElement('head');

$metadata = $xmlDoc->createElement('metadata');
$metadata->setAttribute('xmlns:ttm', 'http://www.w3.org/ns/ttml#metadata');

$metadata->appendChild($xmlDoc->createElement('ttm:copyright', 'TVB (c)')); 

$styling = $xmlDoc->createElement('styling');

$style = $xmlDoc->createElement('style');

$style->setAttribute('xml:id', 's1');
$style->setAttribute('tts:color', 'white');
$style->setAttribute('tts:fontFamily', 'proportionalSansSerif');
$style->setAttribute('tts:fontSize', '35px');
$style->setAttribute('tts:textOutline', 'black 2px 0px');
$style->setAttribute('tts:textAlign', 'center');
$style->setAttribute('tts:origin', '10% 85%');
$style->setAttribute('tts:extent', '80% 10%');

$styling->appendChild($style); 

$layout = $xmlDoc->createElement('layout');

$region = $xmlDoc->createElement('region');

$region->setAttribute('xml:id', 'subtitleArea');
$region->setAttribute('style', 's1');
$region->setAttribute('tts:displayAlign', 'after');

$layout->appendChild($region); 

$head->appendChild($metadata); 
$head->appendChild($styling); 
$head->appendChild($layout); 

$body = $xmlDoc->createElement('body');

$div = $xmlDoc->createElement('div');
$div->setAttribute('region', 'subtitleArea');

$raw_path = $_GET["p"];

$rawSubtitle = new DOMDocument();
$rawSubtitle->load($raw_path);

foreach ($rawSubtitle->getElementsByTagName('p') as $subtitle)
{
	$begin = $subtitle->getAttribute('begin');
	$end = $subtitle->getAttribute('end');

	$times = explode(":", $begin);
	$new_begin = $times[0] . ":" . $times[1] . ":" . $times[2] . "." . $times[3];
	$times = explode(":", $end);
	$new_end = $times[0] . ":" . $times[1] . ":" . $times[2] . "." . $times[3];

	$word = $subtitle->nodeValue;

	$p = $xmlDoc->createElement('p');

	$p->setAttribute('begin', $new_begin);
	$p->setAttribute('end', $new_end);
	$p->nodeValue = $word;

	$div->appendChild($p);
}

$body->appendChild($div); 

$tt->appendChild($head);
$tt->appendChild($body); 

$xmlDoc->appendChild($tt); 

echo $xmlDoc->saveXML();

?>   
