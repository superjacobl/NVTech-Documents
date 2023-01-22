﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NVTech_Documents.Controllers;

[Route("api/docs")]
public class DocumentController : Controller
{
	// GET: DocumentController
	public ActionResult Index()
	{
		return View();
	}

	[Route("/api/docs/{**path}")]
	public ActionResult GetDoc(string path)
	{
		return View();
	}

	// GET: DocumentController/Details/5
	public ActionResult Details(int id)
	{
		return View();
	}

	// GET: DocumentController/Create
	public ActionResult Create()
	{
		return View();
	}

	// POST: DocumentController/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}

	// GET: DocumentController/Edit/5
	public ActionResult Edit(int id)
	{
		return View();
	}

	// POST: DocumentController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(int id, IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}

	// GET: DocumentController/Delete/5
	public ActionResult Delete(int id)
	{
		return View();
	}

	// POST: DocumentController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(int id, IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}
}
